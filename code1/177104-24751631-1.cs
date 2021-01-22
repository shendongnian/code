    using (var sw = File.Create(Path.Combine(txtPath.Text, "UTF8.csv")))
    {
        var preamble = Encoding.UTF8.GetPreamble();  
        sw.Write(preamble, 0, preamble.Length);  
        var data = Encoding.UTF8.GetBytes("懘荧,\"Hello\",text");  
        sw.Write(data, 0, data.Length);
    }
