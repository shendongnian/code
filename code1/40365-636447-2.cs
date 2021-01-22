        Dictionary<string, ColorData> items = new Dictionary<string, ColorData>();
        foreach(DataRow row in table.Rows) {
            string name = row["Color"].ToString().Trim();
            ColorData cData;
            if (items.TryGetValue(name, out cData)) {
                cData.Count++;
            } else {
                cData.Add(name);
                colorCodes.Add(cData);
                items.Add(name, cData);
            }
        }
