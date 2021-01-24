    public Tuple<List<String>, List<Double>, List<Double>> GetEventData(Database db)
    {
    var dict = JsonConvert.DeserializeObject<Dictionary<string, Item>>(db);
    
    List<String> Item_Name = new List<String>();
    List<double> Sell_Price = new List<double>();
    List<double> Buy_Price = new List<double>();
    
    foreach (string key in dict.Keys)
    {
        Item_Name.Add(dict[key].name);
        Sell_Price.Add(Convert.ToDouble(dict[key].sell_average));
        Buy_Price.Add(Convert.ToDouble(dict[key].buy_average));
    }
    
    Tuple t = Tuple.Create(Item_Name, Sell_Price, Buy_Price);
    return t;
    }
