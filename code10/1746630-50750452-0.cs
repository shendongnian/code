    try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(Server.MapPath("~/App_Data/pubkey.pem")))
                {
    	        // Read the stream to a string, and write the string to the console.
                    string doc = sr.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine(doc);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("The file could not be read:");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
