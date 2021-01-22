    class Example {
      [XmlIgnore]
      public double[] DoubleValue { get ... set ... }
      // note: + sign was missing in the original code
      public string ArrayOfDouble {
        get { return DoubleValue.Select(x => x.ToString()).Aggregate( (x,y) => x + " " + y); }
        set { Doublevalue = value.Split(' ').Select(x => Double.Parse(x)).ToArray(); }
      }
    }
         
