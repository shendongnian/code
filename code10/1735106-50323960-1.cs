     JObject jsonObj= JObject.parse(strJSON);
     JObject  PKTDL=jsonObj["PKTDTL"] as JObject;
     IList<string> keys = PKTDL.Properties().Select(p => p.Name).ToList(); // this gives column names
     StringBuilder sb=new StringBuilder();
     string headers="";
     foreach(string key in keys)
     {
       headers+=","+key;
     }  
     sb.AppendLine(headers.TrimStart(','));
     foreach(JObject j in jsonObj["PKTDTL"]) //if jobject doesnt work try "JToken j"
     {
        string values="";
        foreach(string key in keys)
        {
           values+=","+jsonObj["PKTDTL"][key];
        }
        sb.AppendLine(values.TrimStart(','));
     }
      
       File.WriteAllText(filePath, sb.ToString());
