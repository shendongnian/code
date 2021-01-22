        using (StreamWriter sw = new StreamWriter(@"S:\bob.smith\File_Renames.txt")) 
        { 
            //Sanitize and remove invalid chars   
            foreach (string Files2 in filePath) 
            { 
                try 
                { 
                    if (regex.Match(Files2).Success) 
                    {
                        Label l = new Label();
                        l.Content = Files2;
                        listview.Items.Add(l);
                    }
                    string filenameOnly = Path.GetFileName(Files2); 
                    string pathOnly = Path.GetDirectoryName(Files2); 
                    string sanitizedFilename = regEx.Replace(filenameOnly, replacement); 
                    string sanitized = Path.Combine(pathOnly, sanitizedFilename); 
                    sw.Write(sanitized + "\r\n"); 
                    System.IO.File.Move(Files2, sanitized); 
 
                } 
                //error logging 
                catch(Exception ex) 
                { 
                    StreamWriter sw2 = new StreamWriter(@"S:\bob.smith\Error_Log.txt"); 
                    sw2.Write("ERROR LOG"); 
                    sw2.WriteLine(DateTime.Now.ToString() + ex + "\r\n"); 
                    sw2.Flush(); 
                    sw2.Close(); 
 
                } 
            } 
        }
