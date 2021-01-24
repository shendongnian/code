    iAnywhere.Data.SQLAnywhere.SAConnection myConnection = null;
            try
            {
                myConnection = new iAnywhere.Data.SQLAnywhere.SAConnection(conStrMonitor);
                myConnection.Open();
            }
            catch (Exception exp)
            {
                myConnection = null;
                throw exp;
            }
            iAnywhere.Data.SQLAnywhere.SACommand myCommand = myConnection.CreateCommand();
            myCommand.CommandText = "Select art_artnr, art_ben from monitor.ARTIKEL where art_artnr = 'VSV203798'";
            iAnywhere.Data.SQLAnywhere.SADataReader myDataReader = myCommand.ExecuteReader();
            
            while (myDataReader.Read())
            {
                //do stuff here
            }
            myDataReader.Close();
            myConnection.Close();
