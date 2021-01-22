    using System.IO;
    using System.Text;
    using (StreamWriter sw = new StreamWriter(File.Open(myfilename, FileMode.Create), Encoding.WhateverYouWant))
    {    
        sw.WriteLine("my text...");     
    }
