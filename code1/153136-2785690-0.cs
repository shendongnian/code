    class Blah {
      public string Property { get; private set; }
    }
    var blah = new Blah();
    typeof(Blah).GetProperty("Property").SetValue(blah, "newValue", null);
    // at this stage blah.Property == "newValue"
