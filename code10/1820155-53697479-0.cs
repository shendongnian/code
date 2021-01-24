    var headers = new HttpClient().DefaultRequestHeaders;
    
    PropertyInfo[] properties = headers.GetType().GetProperties();
    foreach (var property in properties)
          Console.WriteLine(property.Name);
