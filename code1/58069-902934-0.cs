    class Example {
      [XmlIgnore]
      public double[] DoubleValue { get ... set ... }
    
      public string ArrayOfDouble {
        get { return DoubleValue.Select(x => x.ToString()).Aggregate( (x,y) => x + " " y); }
        set { Doublevalue = value.Split(" ").Select(x => Double.Parse(x)).ToArray(); }
      }
    }
         
