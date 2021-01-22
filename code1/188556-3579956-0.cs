            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();
    
            System.Net.WebClient wc = new System.Net.WebClient();
            string s = wc.DownloadString("http://steamcommunity.com/id/test?xml=1");
            System.Text.RegularExpressions.Regex re = new Regex("\\<steamID64\\>(\\d+)\\</steamID64\\>");
            System.Text.RegularExpressions.Match m = re.Match(s);
            if (m != null && m.Captures.Count != 0) Response.Write("steamID64: " + m.Captures[0].Value + " <br/>");
            stopwatch.Stop();
    
            long time = stopwatch.ElapsedMilliseconds;
            Response.Write("Time Elapsed (1):" + time.ToString() +" <br/>");
    
            stopwatch.Reset();
            stopwatch.Start();
    
            System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader("http://steamcommunity.com/id/test?xml=1");
    
            stopwatch.Reset();
            stopwatch.Start();
    
            while (reader.Read())
            {
                if (reader.Name.Equals("steamID64"))
                {
                    reader.Read();
                    stopwatch.Stop();
    
                    time = stopwatch.ElapsedMilliseconds;
                    s = reader.Value;
                    break;
                }
            }
            
            Response.Write("<br/>steamID64: " + s );
            Response.Write("<br/>Time Elapsed (2):" + time.ToString() + " <br/>");
        
