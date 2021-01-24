    public static List<object> GetMostLikelyType(List<string> inputs)
    {
        List<object> result = new List<object>() ;
        int num;
        double d;
        DateTime dt;
        bool b;
        TimeSpan ts;
        DateTimeOffset dto;
        if (inputs.All(i => int.TryParse(i, out num)))
            result = inputs.Select(x => (object)int.Parse(x)).ToList();
        else if (inputs.All(i => double.TryParse(i, out d)))
            result = inputs.Select(x => (object)double.Parse(x)).ToList();
        else if (inputs.All(i => DateTime.TryParse(i, out dt)))
            result = inputs.Select(x => (object)DateTime.Parse(x)).ToList();
        else if (inputs.All(i => bool.TryParse(i, out b)))
            result = inputs.Select(x => (object)bool.Parse(x)).ToList();
        else if (inputs.All(i => TimeSpan.TryParse(i, out ts)))
            result = inputs.Select(x => (object)TimeSpan.Parse(x)).ToList();
        else if (inputs.All(i => DateTimeOffset.TryParse(i, out dto)))
            result = inputs.Select(x => (object)DateTimeOffset.Parse(x)).ToList();
        else
            result = inputs.Select(x => (object)x.ToString()).ToList();
        return result;
    }
