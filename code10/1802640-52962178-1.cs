    public void CFExport(string jsonFile)
    {
        string ItemIDField = "invItemID";
        string ItemIDValue;
    
        using (StreamReader r = new StreamReader(jsonFile))
        {
            var Idx = JsonConvert.DeserializeObject<JSONMain>(r);
    
            foreach(var field in Idx.Index.Fields.Field) 
            {
                if(field.Name == ItemIDField)
                {
                    ItemIDValue = field.Value;
                }
            }
        }
    }
    
