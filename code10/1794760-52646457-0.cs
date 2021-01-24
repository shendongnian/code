      public static Dictionary<string, object> GetProperties<Derived, Base>()
      {
            return Assembly
                .GetAssembly(typeof(Derived))
                .GetTypes()
                .OrderBy(x => x.IsSubclassOf(typeof(Base)))
                .SelectMany(x => x.GetProperties())
                .GroupBy(x => x.Name)
                .Select(x => x.First())
                .ToDictionary(x => x.Name, x => (object)x.Name);
      }
