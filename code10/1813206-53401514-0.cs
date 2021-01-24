    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace Q_53401300
    {
        class Program
        {
    
            static string dirConta = "C:\\temp2\\ListOfPWD.txt";
    
            static void Main(string[] args)
            {
                buttonGravaPass_Click(null, null);
    
            }
    
            private static void buttonGravaPass_Click(object sender, EventArgs e)
            {
                List<string> newLinesToWrite = new List<string>();
                using (System.IO.StreamReader sr = new StreamReader(dirConta))
                {
                    string currentLine = string.Empty;
                    while ((currentLine = sr.ReadLine()) != null)
                    {
                        string[] parts = currentLine.Split(new char[] { '|' });
                        //if (parts[0] == Users.user)
                        //{
                        parts[0] = parts[0].Remove(parts[0].Length - 5);
                        parts[1] = parts[1] + "12345";
                        newLinesToWrite.Add($"{parts[0]}|{parts[1]}");
                        //}
                    }
                }
                System.IO.File.WriteAllLines(dirConta, newLinesToWrite);
            }
        }
    }
