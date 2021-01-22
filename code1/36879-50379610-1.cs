        public static string CreateNewOutPutFile()
        {
            const string RemoveLeft = "YourApplicationName";
            const string RemoveRight = ".txt";
            const string searchString = RemoveLeft + "*" + RemoveRight;
            const string numberSpecifier = "0000";
            int maxTempNdx = -1;
            string fileName;
            string [] Files = Directory.GetFiles(Directory.GetCurrentDirectory(), searchString);
            foreach( string file in Files)
            {
                fileName = Path.GetFileName(file);
                string stripped = fileName.Remove(fileName.Length - RemoveRight.Length, RemoveRight.Length).Remove(0, RemoveLeft.Length);
                if( int.TryParse(stripped,out int current) )
                {
                    if (current > maxTempNdx)
                        maxTempNdx = current;
                }
            }
            maxTempNdx++;
            fileName = RemoveLeft + maxTempNdx.ToString(numberSpecifier) + RemoveRight;
            File.CreateText(fileName); // optional
            return fileName;
        }
