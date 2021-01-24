     private string LastValue = "";
     public string check_for_changes(string value)
     {
         int counter = 0;
         string line;
     
     
         System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\EFB\AppData\Roaming\Microsoft\FSXDemo\fsx.CFG");
     
         while ((line = file.ReadLine()) != null)
         {
             if (line.Contains(value))
             {
                 string NewValue = line.Substring(value.Length);
                 if (NewValue != LastValue)
                      testtb.Text = "new Value is : " + NewValue;
                 LastValue = NewValue;
                 break;
             }
     
             counter++;
         }
     
         Console.WriteLine("Line number: {0}", counter);
     
         file.Close();
         return value;
     }
