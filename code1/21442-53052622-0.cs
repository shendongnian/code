    bool deleted = false;
            do
            {
                try
                {
                    Directory.Delete(rutaFinal, true);                    
                    deleted = true;
                }
                catch (Exception e)
                {
                    string mensaje = e.Message;
                    if( mensaje == "The directory is not empty.")
                    Thread.Sleep(50);
                }
            } while (deleted == false);
