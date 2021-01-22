    countries.ForEach(ctry => {
         Console.Write(ctry.Name + " ");
         foreach (var city in ctry.cities)
         {
             Console.Write(city.Name + " ");
         }
         Console.WriteLine("");
    });
