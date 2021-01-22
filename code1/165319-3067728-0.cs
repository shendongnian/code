 static void YeniMethodListele()
        {
            List&#60;Calısan&#62; myList = new List&#60;Calısan&#62;();
            myList.Add(new Calısan() { Ad = "yusuf", SoyAd = "karatoprak", ID = 1 });
            foreach (Calısan item in myList)
            {
                Console.WriteLine(item.Ad.ToString());
            }
        }</code></pre>
