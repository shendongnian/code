    serialPort1.PortName = "COM1";
    // other settings ...
    serialPort1.Encoding = Encoding.ASCII;
    serialPort1.Open();
        
    using (System.IO.TextReader reader = System.IO.File.OpentText("file.txt"))
    { 
        string line;
    
        while ((line = reader.ReadLine()) != null)
        {
           serialPort1.WriteLine(line);
        }
    }
