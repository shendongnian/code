    public string CustomBind(object data)
    {
       if(data is List<string>)
       {
          List<string> list = data as List<string>;
    
          return string.Join("\n", list.ToArray();
       }
    }
