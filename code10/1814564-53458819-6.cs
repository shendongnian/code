    Canteen[] canteens = DeserializeAPIResults<Canteen[]>(json);
    foreach (var canteen in canteens)
    {
        string name = canteen.Name;
        string src = canteen.Src;
        JToken food = canteen.Food;
        if (food.Type == JTokenType.Object)
        {
            Dictionary<string, string> foods = food.ToObject<Dictionary<string, string>>();
        }
        else if (food.Type == JTokenType.Array)
        {
            //Do something if "foods" is empty array "[]"
        }
    }
