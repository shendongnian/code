     private static void GetHeadStoneData()
     {
        using(StreamReader read = new StreamReader("YourFile.txt"))
        {
           const char Delimter = '/';
           string data;
           while((data = read.ReadLine()) != null)
           {
                string[] headStoneInformation = data.Split(Delimter);
                //Do your stuff here, e.g. Console.WriteLine("{0}", headStoneInformation[0]);
           }
        }
     }
