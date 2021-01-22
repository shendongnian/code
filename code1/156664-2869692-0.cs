    DataRow dr = dt.NewRow();
    
    //TRANSFORM RESPONSE LABELS INTO COLUMNS
    foreach (XmlNode fieldNode in currentXml.SelectNodes("response/fields/field"))
    {
        string label = fieldNode.SelectSingleNode("label").InnerText ?? "Unknown";
        string value = fieldNode.SelectSingleNode("value").InnerText;
        //CHECK IF ARBITRARY LABEL WAS ADDED BEFORE
        if (!dt.Columns.Contains(label))
        {
            //CREATE COLUMN FOR NEW LABEL
            dt.Columns.Add(label);
        }
        dr[label] = value;
    }
    dt.Rows.Add(dr);
    }
    ds.Tables.Add(dt);
