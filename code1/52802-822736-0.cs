    struct Data {
      public int Value;
      public bool IsStart;
    }
    
    public static IEnumerable<Data> Split(this Region region) {
      yield return new Data() { Value = region.StartLocation, IsStart=true};
      yield return new Data() { Value = region.EndLocation, IsStart=false};
    }
