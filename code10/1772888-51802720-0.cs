    private static IEnumerable<PropertyInfo> PublicProps(Type value) {
      HashSet<PropertyInfo> emitted = new HashSet<PropertyInfo>();
      BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
      List<PropertyInfo> agenda = value
        .GetProperties(flags)
        .ToList();
      while (agenda.Any()) {
        for (int i = agenda.Count - 1; i >= 0; --i) {
          PropertyInfo item = agenda[i];
          agenda.RemoveAt(i);
          if (!emitted.Add(item))
            continue;
          yield return item;
          agenda.AddRange(item.PropertyType.GetProperties(flags));
        }
      }
    }
