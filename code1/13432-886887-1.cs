    using System;
    using log4net; //or another logging platform
    
    namespace GenApp.Utils
    {
      public class ErrorHandler
      {
        public static void Trap ( Bo.User objUser, ILog logger, System.Diagnostics.StackTrace st, Exception ex )
        {
          if (ex is NullReferenceException)
          { 
          //do stuff for this ex type
          } //eof if
    
          if (ex is System.InvalidOperationException) //comm -- occurs when no result set was found !!!
          {
            //do stuff for this ex type
          } //eof if
    
          if (ex is System.IndexOutOfRangeException) //comm -- occurs when no result set was found !!!
          {
            //do stuff for this ex type
          } //eof if
    
          if (ex is System.Data.SqlClient.SqlException)
          {
            //do stuff for this ex type
          } //eof if
    
          if (ex is System.FormatException)
          {
            //do stuff for this ex type
          } //eof if
    
          if (ex is Exception)
          {
            //do stuff for this ex type
          } //eof catch
    
        } //eof method 
    
      }//eof class 
    } //eof namesp
