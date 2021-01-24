     class Program
    {
        double dollarsToPounds;
        double dollarsToEuros;
        static void Main(string[] args)
        {
            Program program = new Program();
            string URL = "https://openexchangerates.org/api/latest.json?app_id=4837847d2bc64fc496cf325525c5cf0d";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("GBP"));
            request.PreAuthenticate = true;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string streamString = reader.ReadToEnd();
                string[] streamArray = Regex.Split(streamString, "\n|: |,\\s*");
                
                foreach (string s in streamArray)
                {
                    if (s.Equals("\"GBP\""))
                    {
                        int element = Array.IndexOf(streamArray,s);
                        string dTPString = streamArray[element + 1];
                        
                        program.dollarsToPounds = Convert.ToDouble(dTPString);
                    }
                    if (s.Equals("\"EUR\""))
                    {
                        int element = Array.IndexOf(streamArray, s);
                        string dTEString = streamArray[element + 1];
                        program.dollarsToEuros = Convert.ToDouble(dTEString);
                    }
                }
            }
            Console.WriteLine(program.dollarsToPounds); //works!
            Console.WriteLine(program.dollarsToEuros); //works!
        }
    }
