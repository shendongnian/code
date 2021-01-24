        if(File.Exists("SavedData.dat"))
        {
            using (StreamReader sr = new StreamReader("SavedData.dat"))
            {
                string line = "";
                while((line = sr.ReadLine()) != null)  
                {
                    string[] lineData = line.Split('|');
                    if(lineData.Length == 3)
                    {
                        string currentTbName = lineData[0];
                        string currentTbText = lineData[1];
                        string currentLablText = lineData[2];
                      
                        //LOAD THEM AS NORMAL
                    }
                }
            }
        }
