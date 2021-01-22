    dynamic data = serializer.Deserialize(json, typeof(object));
    data.Date; // "21/11/2010"
    data.Items.Count; // 2
    data.Items[0].Name; // "Apple"
    data.Items[0].Price; // 12.3 (as a decimal)
    data.Items[1].Name; // "Grape"
    data.Items[1].Price; // 3.21 (as a decimal)
