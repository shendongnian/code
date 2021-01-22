    using (var client = new TcpClient())
    {
        client.Connect("www.site.com", 80);
        using (var stream = client.GetStream())
        {
            var writer = new StreamWriter(stream);
            writer.WriteLine("GET /default/defaultcatg.asp?catg=69569 HTTP/1.1");
            writer.WriteLine("Host: www.site.com");
            writer.WriteLine("User-Agent: Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.2) Gecko/20090805 Shiretoko/3.5.2");
            writer.WriteLine("Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            writer.WriteLine("Accept-Language: en-us,en;q=0.5");
            writer.WriteLine("Accept-Charset: ISO-8859-1,utf-8;q=0.7,*;q=0.7");
            writer.WriteLine("Connection: close");
            writer.WriteLine(string.Empty);
            writer.WriteLine(string.Empty);
            writer.WriteLine(string.Empty);
            writer.Flush();
            var reader = new StreamReader(stream);
            var response = reader.ReadToEnd();
            // When looking at the response it correctly reads 
            // Location: http://www.site.com/buy/κινητή-σταθερή-τηλεφωνία/c/cn69569/
        }
    }
