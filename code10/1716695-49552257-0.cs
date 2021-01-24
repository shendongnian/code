    var myData = new SomeClass();
    myData.Artikli = new List<DetailClass>() { new DetailClass() { FieldDetail1 = "asd", FieldDetail2 = "sdfd", FieldDetail3 = "sdfsg" } };
  
    foreach (var obj in myData.Artikli)
    {
       foreach (var item in obj.GetType().GetProperties())
       {
          if (item.PropertyType == typeof(string))
          {
             var name = item.Name;
             var val = item.GetValue(obj);
             Console.WriteLine(name + ", " + val);
          }
       }
    }
