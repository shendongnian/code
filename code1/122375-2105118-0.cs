    public class Manufacturer
    {
      public string Name { ... }
      public IList<Probe> Probes { ... }
    }
    
    public class Probe
    {
      public string Name { ... }
      public int Elements { ... }
      public ProbeSettings Settings { ... }
    }
    
    public class ProbeSettings
    {
      public int RandomSetting;
    }
