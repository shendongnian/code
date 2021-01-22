    [Serializable]
    public class MyClass
    {
      public int Age { get; set; }
      [XmlIgnore]
      public bool AgeSpecified { get { return Age >= 0; } }
      public int MyClassB { get; set; }
    }
    
    [Serializable]
    public class MyClassB
    {
      public int RandomNumber { get; set; }
    }
