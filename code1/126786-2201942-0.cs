    //A list that holds my data
    private List<Location> locationCollection = new List<Location>();
    
    
    public bool Load()
    {
                //For debug purposes
                Console.WriteLine("Loading Data");
                XmlSerializer serializer = new XmlSerializer(typeof(List<Location>));
                FileStream fs = new FileStream("CurrencyData.xml", FileMode.Open);
                locationCollection = (List<Location>)serializer.Deserialize(fs);
                fs.Close();
                Console.WriteLine("Data Loaded");
                return true;
    }
