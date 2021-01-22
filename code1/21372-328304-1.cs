    bool IsDefined(this Type t, string name) {
       if (!t.IsEnum) throw new ArgumentException();
 
       return Enum.IsDefined(t, name);
    }
    typeof(FileExtension).IsDefined(file.Extension);
