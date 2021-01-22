            static void Main(string[] args)
        {
            //...
           // using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
           // {
            HtmlDocument doc = new HtmlWeb().Load("http://www.freeclup.com");
             
                foreach (HtmlNode span in doc.DocumentNode.SelectNodes("//span"))
                {
                    Console.WriteLine(span.InnerText);
                }
                Console.ReadKey();
          //  }
        }
