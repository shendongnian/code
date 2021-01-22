    using System;
    using System.IO;
    
    public class Test
    {    
        static void Main()
        {
            StreamWriter creditsFile = new StreamWriter(File.Open("test.txt", 
                                              FileMode.CreateNew));
    
            creditsFile.WriteLine("code\\inc");
            
            creditsFile.Close();
            creditsFile.Dispose();
            
            File.Move("test.txt", "test2.txt");
        }
    }
