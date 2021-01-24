    string json = "start";
    using (StreamReader r = new StreamReader(testFile)) {
        while (!String.IsNullOrWhiteSpace(json)){
          json = r.ReadLine();
          dynamic jsonObject = JsonConvert.DeserializeObject(json);
          //DO YOUR MAGIC HERE
         }
     }
