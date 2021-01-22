        private const string URL = "http://housing.udayton.edu/php/lottery/clock.php";
        private const string StartString = "<p align=\"center\"><b>";
        private const string EndString = "</b>";
        private DateTime getTime()
        {
            HttpWebResponse resp = HttpWebRequest.Create(URL).GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(resp.GetResponseStream());
            String data = reader.ReadToEnd();
            int startIndex = data.IndexOf(StartString) + StartString.Length;
            int endIndex = data.IndexOf(EndString, startIndex);
            String time = data.Substring(startIndex, (endIndex-startIndex)-4);
            return DateTime.Parse(time);
        }
