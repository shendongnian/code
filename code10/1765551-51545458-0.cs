    string Url = "https://www.us-proxy.org/";
            WebRequest wReq = WebRequest.Create(new Uri(Url));
            WebResponse wResp = wReq.GetResponse();
            StreamReader sr = new StreamReader(wResp.GetResponseStream());
            string str = sr.ReadToEnd();
            string[] lines = str.Split('\n');
            Regex Filtrer = new Regex("^([0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3})([0-9]{2,5})$");
            for (int i = 0; i < lines.Length; i++)
            {               
                Match matches = Filtrer.Match(lines[i]);
                listBox1.Items.Add(matches.Groups[1].Value + ":" + matches.Groups[2].Value);
            }
