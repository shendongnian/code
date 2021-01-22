            Microsoft.SqlServer.Management.Smo.Server addDBserver = new  	Microsoft.SqlServer.Management.Smo.Server(ipAddress);
            addDBserver.ConnectionContext.LoginSecure = false;
            addDBserver.ConnectionContext.Login = UserName;
            addDBserver.ConnectionContext.Password = Password;
       
            try
            {
                //*Crerate Databse*
                addDBserver.ConnectionContext.Connect();
                FileInfo filedb = new FileInfo(DB_filepath);
                string scriptdb = filedb.OpenText().ReadToEnd();
                string scriptdb1 = scriptdb.Replace("GO", Environment.NewLine);
                string scriptdb2 = scriptdb1.Replace("\r\nGO\r\n", "");
                addDBserver.ConnectionContext.ExecuteNonQuery(scriptdb2);
                addDBserver.ConnectionContext.Disconnect();
                string Msg;
                    Msg = "db created successfully";
                    return Msg;
                return true;
              
            }
            catch (Exception ex)
            {
           string Msg1 = "db notcreated successfully";
             return ex.Message;
               throw;
            }
        }
            //Database created Successfully
