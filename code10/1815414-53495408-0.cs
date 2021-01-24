using Newtonsoft.Json.JsonWriter
     using (JsonWriter writer = new JsonTextWriter(sw))
     {
         for(int i = 0; i < table.Rows.Count; )
         {
            writer.WritePropertyName(table.Rows[i]["ID"]);
            writer.WriteStartObject();
            DataRow[] idsMatch = table.Select("ID = "+table.Rows[i]["ID"])+"");]
            foreach(DataRow row in idsMatch)
            {
              writer.WritePropertyName("f_sd"+row["F_SD"]);
              writer.WriteStartObject();
              writer.WritePropertyName("value");
              writer.WriteValue(row["VAL"]);
              writer.WriteEndObject();
              i++;
            }
            writer.WriteEndObject();
         }
       }
