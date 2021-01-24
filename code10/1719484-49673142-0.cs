    using System;
    using System.IO;
    using System.Text;
    
    class Test
    {
        public static void Main()
        {
         
            string filePath = @"C:\Users\tib5ka\Desktop\FællesVagtplan-filer\sheet001.htm";
     
            string[] lines  = File.ReadAllLines(filePath, System.Text.Encoding.Default);
            for (int i = 0; i < lines.Length; i++)
            {
               lines[i] = lines[i].Replace("INFOBAR :", "<marquee>Det er froååkosttid.</marquee>");
           
                
            }
    
            File.WriteAllLines(filePath, lines, Encoding.UTF8);
        }
    }
