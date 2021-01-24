    string conv = label.Text;
    var result = con.Split(' ');
    using(StreamWriter sw = new StreamWriter(Response.OutputStream, Encoding.UTF8))
    {
        foreach(var s in result.Distinct()) 
        {
            //using distinct to ensure no repeated items (scraping multiple pages w/ same links possible)
            sw.WriteLine(s);
        }
    }
