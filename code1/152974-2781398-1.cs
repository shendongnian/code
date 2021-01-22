    string filePath = "filepath here";
    if (!System.IO.File.Exists(filePath))
    {
        System.IO.FileStream f = System.IO.File.Create(filePath);
        f.Close();
    }
    using (System.IO.StreamWriter sw = System.IO.File.AppendText(filePath))
    { 
        //write my text 
    }
