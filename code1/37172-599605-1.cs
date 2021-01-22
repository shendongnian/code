				return false;
			} //eof catch
			catch (System.InvalidOperationException ioe) //comm -- occurs when no result set was found !!!
			{
				System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace ();
				string methodName = st.GetFrame ( 1 ).GetMethod ().Name;
				string className = st.GetFrame ( 1 ).GetFileName ();
				int lineNumber = st.GetFrame ( 1 ).GetFileLineNumber ();
				string encryptedErrorCode = String.Empty;
				encryptedErrorCode += "className - " + className + " methodName ";
				encryptedErrorCode += methodName + " lineNumber " + lineNumber.ToString ();
				encryptedErrorCode += userObj.DomainName;
				if (System.Convert.ToInt16 ( BL.Conf.Instance.Vars["EncryptErrorMessages"] ) == 1)
					encryptedErrorCode = Utils.DataEncryption.EncryptString ( encryptedErrorCode, userObj.DomainName );
				userObj.Mc.Msg = "An error in the application occurred. Report the following error code " + encryptedErrorCode;
				userObj.Mc.ClassName += className + " ; " ;
				userObj.Mc.MethodName += methodName + " ; " ;
				userObj.Mc.DebugMsg += ioe.Message;
				
				if (DbDebugger.DebugAppError ( ref userObj ) == false)
				{
					userObj.Mc.Msg = "Failed to debug application error at " + methodName;
