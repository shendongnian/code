       public static string NewFileName()
        {
            const string RemoveLeft = "YourApplicationName";
            const string RemoveRight = ".txt";
            const string searchString = RemoveLeft + "*" + RemoveRight;
            const string numberSpecifier = "0000";
    
            int maxTempNdx = -1;
    
            string [] Files = Directory.GetFiles(Directory.GetCurrentDirectory(), searchString);
            foreach( string file in Files)
            {
                string stripped = file.Remove(0, RemoveLeft.Length).Remove(file.Length - RemoveRight.Length, RemoveRight.Length);
                if( int.TryParse(stripped,out int current) )
                {
                    if (current > maxTempNdx)
                        maxTempNdx = current;
                }
            }
            maxTempNdx++;
            return RemoveLeft + maxTempNdx.ToString(numberSpecifier) + RemoveRight;
        }
