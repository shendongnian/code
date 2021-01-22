    public void TestFunction(object input)
      try {
        int value = int.Parse(input.ToString());
        SomeOtherFunction(value);
      }
      catch (Exception ex) {
        Console.WriteLine("Could not determine integer value");
      }
    }
