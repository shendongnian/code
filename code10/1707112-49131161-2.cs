    public static List<MyData> getObj(String[] lines)
    {
        Dictionary<Int32, MyData> myDataDict = new Dictionary<Int32, MyData>();
        const String valueStart = "Value: ";
        foreach (String line in lines)
        {
            String[] split = line.Split(',');
            // Too many fail cases; I just ignore any line that stops matching at any point.
            if (split.Length < 3)
                continue;
            String[] numData = split[0].Trim().Split('.');
            if (numData.Length < 5)
               continue;
            // Using the 4th number as property identifier. Could also use the
            // type string, but switch/case on a numeric value is more elegant.
            Int32 prop;
            if (!Int32.TryParse(numData[3], out prop))
               continue;
            // Object index, used to reference the objects in the Dictionary.
            Int32 index;
            if (!Int32.TryParse(numData[4], out index))
               continue;
            String typeDef = split[1].Trim();
            String val = split[2].TrimStart();
            if (!val.StartsWith(valueStart))
               continue;
            val = val.Substring(valueStart.Length);
            MyData data;
            if (myDataDict.ContainsKey(index))
                data = myDataDict[index];
            else
            {
                data = new MyData();
                myDataDict.Add(index, data);
            }
            switch (prop)
            {
                case 0:
                    if (!"Type: DateTime".Equals(typeDef))
                        continue;
                    DateTime dateVal;
                    // Don't know if this date format is correct; adapt as needed.
                    if (!DateTime.TryParseExact(val, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateVal))
                        continue;
                    data.DateTime = dateVal;
                    break;
                case 1:
                    if (!"Type: Integer".Equals(typeDef))
                        continue;
                    Int32 numVal;
                    if (!Int32.TryParse(val, out numVal))
                        continue;
                    data.Index = numVal;
                    break;
                case 2:
                    if (!"Type: String".Equals(typeDef)) continue;
                    data.Value = val;
                    break;
            }
        }
        return new List<MyData>(myDataDict.Values);
    }
