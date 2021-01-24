      public static Dictionary<string, object> GetProperties<Derived, Base>()
      {
            var onlyInterestedInTypes = new[] { typeof(Derived).Name, typeof(Base).Name };
            return Assembly
                .GetAssembly(typeof(Derived))
                .GetTypes()
                .Where(x => onlyInterestedInTypes.Contains(x.Name))
                .OrderBy(x => x.IsSubclassOf(typeof(Base)))
                .SelectMany(x => x.GetProperties())
                .GroupBy(x => x.Name)
                .Select(x => x.First())
                .ToDictionary(x => x.Name, x => (object)x.Name);
      }
