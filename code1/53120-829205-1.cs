    using System;
    
    namespace Utils
    {
      public class ErrorHandler
      {
        
    
        public static void Trap ( ref FB.User userObj, System.Diagnostics.StackTrace st, Exception ex )
        {
          if (userObj == null)
          {
            userObj = new FB.User ();
            FB.User.GiveDefaultUser ( ref userObj );
          }
    
    
          if (ex is NullReferenceException)
          {
            if (userObj == null)
            {
              userObj = new FB.User ();
              FB.User.GiveDefaultUser ( ref userObj );
            }
    
    
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
            userObj.Mc.ClassName += className + " ; ";
            userObj.Mc.MethodName += methodName + " ; ";
            userObj.Mc.DebugMsg += ex.Message;
            //
            if (Providers.nsDbMeta.DbDebugger.DebugAppError ( ref userObj ) == false)
            {
              userObj.Mc.Msg = "Failed to debug application error at " + methodName;
              //Providers.nsDbMeta.Providers.nsDbMeta.DbDebugger.WriteIf ( userObj.Mc.Msg );
            }
    
          } //eof if
    
          if (ex is System.InvalidOperationException) //comm -- occurs when no result set was found !!!
          {
            if (userObj == null)
            {
              userObj = new FB.User ();
              FB.User.GiveDefaultUser ( ref userObj );
            }
    
    
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
            userObj.Mc.ClassName += className + " ; ";
            userObj.Mc.MethodName += methodName + " ; ";
            userObj.Mc.DebugMsg += ex.Message;
            //
            if (Providers.nsDbMeta.DbDebugger.DebugAppError ( ref userObj ) == false)
            {
              userObj.Mc.Msg = "Failed to debug application error at " + methodName;
              //Providers.nsDbMeta.Providers.nsDbMeta.DbDebugger.WriteIf ( userObj.Mc.Msg );
            }
    
          } //eof if
    
          if (ex is System.IndexOutOfRangeException) //comm -- occurs when no result set was found !!!
          {
            if (userObj == null)
            {
              userObj = new FB.User ();
              FB.User.GiveDefaultUser ( ref userObj );
            }
    
    
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
            userObj.Mc.ClassName += className + " ; ";
            userObj.Mc.MethodName += methodName + " ; ";
            userObj.Mc.DebugMsg += ex.Message;
            //
            if (Providers.nsDbMeta.DbDebugger.DebugAppError ( ref userObj ) == false)
            {
              userObj.Mc.Msg = "Failed to debug application error at " + methodName;
              //Providers.nsDbMeta.Providers.nsDbMeta.DbDebugger.WriteIf ( userObj.Mc.Msg );
            }
    
          } //eof if
    
          if (ex is System.Data.SqlClient.SqlException)
          {
            if (userObj == null)
            {
              userObj = new FB.User ();
              FB.User.GiveDefaultUser ( ref userObj );
            }
    
    
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
            userObj.Mc.ClassName += className + " ; ";
            userObj.Mc.MethodName += methodName + " ; ";
            userObj.Mc.DebugMsg += ex.Message;
            //
            if (Providers.nsDbMeta.DbDebugger.DebugAppError ( ref userObj ) == false)
            {
              userObj.Mc.Msg = "Failed to debug application error at " + methodName;
              //Providers.nsDbMeta.Providers.nsDbMeta.DbDebugger.WriteIf ( userObj.Mc.Msg );
            }
    
          } //eof if
    
          if (ex is System.FormatException)
          {
            if (userObj == null)
            {
              userObj = new FB.User ();
              FB.User.GiveDefaultUser ( ref userObj );
            }
    
    
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
            userObj.Mc.ClassName += className + " ; ";
            userObj.Mc.MethodName += methodName + " ; ";
            userObj.Mc.DebugMsg += ex.Message;
            //
            if (Providers.nsDbMeta.DbDebugger.DebugAppError ( ref userObj ) == false)
            {
              userObj.Mc.Msg = "Failed to debug application error at " + methodName;
              //Providers.nsDbMeta.Providers.nsDbMeta.DbDebugger.WriteIf ( userObj.Mc.Msg );
            }
    
          } //eof if
    
          if (ex is Exception)
          {
            if (userObj == null)
            {
              userObj = new FB.User ();
              FB.User.GiveDefaultUser ( ref userObj );
            }
    
    
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
            userObj.Mc.ClassName += className + " ; ";
            userObj.Mc.MethodName += methodName + " ; ";
            userObj.Mc.DebugMsg += ex.Message;
            //
            if (Providers.nsDbMeta.DbDebugger.DebugAppError ( ref userObj ) == false)
            {
              userObj.Mc.Msg = "Failed to debug application error at " + methodName;
              //Providers.nsDbMeta.Providers.nsDbMeta.DbDebugger.WriteIf ( userObj.Mc.Msg );
            }
    
          } //eof catch
        
    
        } //eof method 
    
    
    
      }//eof class CustomException
    } //eof namespace U
