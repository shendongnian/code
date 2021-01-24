      // Given a string
      string source = "Ali||Atay||3||5||izmir";
      // We parse it into specially designed object
      MyClass item = MyClass.Parse(source);
      // Work with Names, Values as we please
      if (item.FirstValue == 3)
        item.FirstValue = 55;
      // If we want a csv representation we can easily obtain it
      string result = item.ToCsv();  
