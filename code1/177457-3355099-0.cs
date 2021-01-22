            for (int i = 1; i <= 81; i++)
            {
                var rqst = (HttpWebRequest)WebRequest.Create("http://www.milliyet.com.tr/Secim2009/api/belediyelist.ashx?sehirid=" + i);
                rqst.Method = "POST";
                rqst.ContentType = "text/xml";
                rqst.ContentLength = 0;
                rqst.Timeout = 3000;
                var rspns = (HttpWebResponse)rqst.GetResponse();
                var reader = new StreamReader(rspns.GetResponseStream());
                form1.InnerHtml += reader.ReadToEnd() + "<br>";
            }
