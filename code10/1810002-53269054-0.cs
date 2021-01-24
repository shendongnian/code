    public static void info(JObject aInfoJSON){
      foreach(var it in aInfoJSON){
         if (it.Key.Equals("str")){/*do something*/}
     
      switch(it.Value.Type)
      {
        case JToken.String:
          if (it.Value.Value<string>().Equals("?"))
            {/*so something*/}
        case JToken.Float:
            if(it.Value.Value<Float>().Equals(0)); 
            {/*so something*/}
      }
    }
