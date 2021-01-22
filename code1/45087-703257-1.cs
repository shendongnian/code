    static string Serialize<T>(T obj)
    {
      var serializer = new XmlSerializer(typeof(T));
      var builder = new StringBuilder();
      using (var writer = new StringWriter(builder))
      {
        serializer.Serialize(writer, obj);
        return builder.ToString();
      }
    }
    static void Main(string[] args)
    {
      var withoutAge = new MyClass() { Age = -1 };
      var withAge = new MyClass() { Age = 20 };
      
      Serialize(withoutAge); // = <MyClass><MyClassB>0</MyClassB></MyClass>
      Serialize(withAge); // = <MyClass><Age>20</Age><MyClassB>0</MyClassB></MyClass>
    }
