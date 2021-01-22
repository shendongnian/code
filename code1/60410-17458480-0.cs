     System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
 
     string s = "unicode";
 
     //string to utf
     byte[] utf = System.Text.Encoding.UTF8.GetBytes(s);
 
     //utf to string
     string s2= System.Text.Encoding.UTF8.GetString(utf);
