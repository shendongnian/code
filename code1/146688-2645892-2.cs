    protected override void Render(HtmlTextWriter writer)
    {
        using (System.IO.MemoryStream MS = new System.IO.MemoryStream())
        {
            using (System.IO.StreamWriter SW = new System.IO.StreamWriter(MS))
            {
                HtmlTextWriter NW = new HtmlTextWriter(SW);
                base.Render(NW);
                NW.Flush();
                MS.Position = 0;
                using (System.IO.StreamReader SR = new System.IO.StreamReader(MS))
                {
                    string html = SR.ReadToEnd();
                    MatchCollection MC = Regex.Matches(html, "<img.*?(?<OnError>onerror=\".*?\").*?>");
                    foreach (Match M in MC)
                    {
                        if (M.Success)
                        {
                            html = html.Replace(M.Groups["OnError"].Value, "");
                        }
                    }
                    Response.Write(html);
                    SR.Close();
                }
            }
        }
    } 
