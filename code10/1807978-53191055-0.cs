    List<ICommomInterface> items = new List<ICommomInterface>();
    items.AddRange(await sheet.GetFunctionCodes());
    items.AddRange(await sheet.GetInputReferences());
    items.AddRange(await sheet.GetOutputReferences());
    items.AddRange(await sheet.GetTexts());
    
    items.foreach(item =>
    {
        item.Attributes.ForEach(attrib =>
        {
            DataRow row = GetRow(cltAttributeTable, controlLogicClt, sheet);
            if(item is IFunctionCode){
                row["OBJECT_TYPE"] = "FUNCTION CODE";
            } else if(_other types_)
            {
            }
            row["OBJECT_NAME"] = item.Name;
            row["ATTRIBUTE_NAME"] = attrib.Type;
            row["ATTRIBUTE_VALUE"] = attrib.Value;
            cltAttributeTable.Rows.Add(row);
        });
    });
