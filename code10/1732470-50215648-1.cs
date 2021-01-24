    var lines = System.IO.File.ReadAllLines("somedoc.txt");
    List<DTO> dtos = new List<DTO>();
    foreach(var line in lines)
    {
    
       Console.WriteLine(line);
       //split it to words
       var lineFields = line.Split(null);
    
       //first will be the field's value
       var field = lineFields.FirstOrDefault(f => !string.IsNullOrEmpty(f));
    
       //others will be the field's values
       var values = line.Where(val => !string.IsNullOrEmpty(val) && !string.Equals(field, val)).Select(elem => short.Parse(elem)).ToList();
       DTO dtoObj = new DTO();
       if(field.Equals("NAME"))dtoObj.Name = field;
       if(field.Equals("INDEX")) dtoObj.Index.AddRange(values);
       if(line.Contains("END")
       {
          //end it, and parse it to next object.
       }
    }
