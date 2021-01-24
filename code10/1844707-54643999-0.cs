    enum MyEnum {
      Asterix, Hand, Question
    }
    public static void Main(string[] args)
    {
      var field = typeof(MyEnum).GetField("Asterix");
      var myEnum = field.GetValue(field);
    }
