        dynamic ReturnValue = JsonConvert.DeserializeObject(jsonstring);
    
    try
    {
          var a = ReturnValue.ANDE; // will work if it has ANDE property.
          // do what you would do with ANDE
    }
    catch{}
    try
    {
          var a = ReturnValue.DAR; // will work if it has DAR property.
          // do what you would do with DAR
    }
    catch{}
