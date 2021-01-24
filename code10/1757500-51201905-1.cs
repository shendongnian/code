    public static IEnumerable<CheckBox> test2()
    {
       CheckBox checkbox1 = new CheckBox();
       CheckBox checkbox2 = new CheckBox();
       CheckBox checkbox3 = new CheckBox();
       List<CheckBox> list = new List<CheckBox> { checkbox1, checkbox2, checkbox3 };
    
       foreach (var entry in list)
       {
          yield return entry;
       }
    }
