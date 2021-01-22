    IEnumerable<string> GetNames(this Type t) {
       if (!t.IsEnum) throw new ArgumentException();
       return Enum.GetNames(t);
    }
    typeof(FileExtensions).GetNames().Any(e=>e.ToString().Equals(file.Extension));
