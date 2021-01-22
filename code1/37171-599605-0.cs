			#region Action
			try
			{
				using (Database db = new Database ( _ConnectionString ))
				{
					DbCommand cmd = db.GetStoredProcedureCommand ( procedureName );
					db.AddInParam ( cmd, "@domain_user", DbType.String, (object)domainName );
					GenApp.Core.Providers.nsDbMeta.DbDebugger.WriteIf ( ref userObj , "METHOD START --- MetaDbControl.cs RunProcGetDs + \n" );
					ds = db.ExecuteDataSet ( cmd );
					Utils.Debugger.DebugDataSet("from RunProcGetDs ", ref ds);
					//debug msg = "Select the values for your reports";
					return true;
				} //eof using
			} //eof try
			#endregion Action
			#region CatchExceptionsAdv4
			catch (NullReferenceException nre)
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
				userObj.Mc.DebugMsg += nre.Message;
				
				if (DbDebugger.DebugAppError ( ref userObj ) == false)
				{
					userObj.Mc.Msg = "Failed to debug application error at " + methodName;
