    public void TestFunction(object input)
      try {
        int value = Convert.ToInt32(input);
        SomeOtherFunction(value);
      }
      catch (Exception ex) {
        Console.WriteLine("Could not determine integer value");
      }
    }
