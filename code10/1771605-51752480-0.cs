     class Program
    {
        static void Main(string[] args)
        {
            string[] files = System.IO.Directory.GetFiles(@"Some Directory");
            int counter = 0;
            foreach (var i in files)
            {
               
                string[] lines;
                lines = System.IO.File.ReadAllLines(i);
                
               
                for(int j=0;j<lines.Length;j++)
                {
                    StringBuilder str = new StringBuilder();
                    string str1 ="";
                    string str2 = "";
                    string fullLine = lines[j];
                    string sub = lines[j].Substring(0, 2);
                    if(sub.Equals("01"))
                    {
                        str1 = fullLine.Remove(44, 2);
                        str2 = str1.Insert(45, "0");
                        str.Append(str2);
                    }
                    else if(sub.Equals("02"))
                    {
                        str1=fullLine.Remove(2, 2);
                        str2 = str1.Insert(2, "0");
                        str.Append(str2);
                    }
                    else if(sub.Equals("99"))
                    {
                        str.Append(lines[j]);
                    }
                    lines[j] = str.ToString();
                    
                }
                System.IO.File.WriteAllLines(someDirectory, lines);
                counter++;
                
            }
            
        }
    }
