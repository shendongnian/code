    string fileName = "blabla.hex";
    StreamReader f1 = File.OpenText(fileName);
    StreamWriter f2 = File.CreateText(fileName + ".temp_");
                   
    while (!f1.EndOfStream)
    {
        String s = f1.ReadLine();
        //change the content of the variable 's' as you wish 
        f2.WriteLine(s);   
    }
   
    f1.Close();
    f2.Close();
    File.Replace(fileName + ".temp_", fileName, null);
