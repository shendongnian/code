     public override int GetHashCode() {
            int hash = 17;
      hash = hash * 23 + DrillDownLevel.GetHashCode();
      hash = hash * 23 + Year.GetHashCode();
      if (Month.HasValue) {
        hash = hash * 23 + Month.Value.GetHashCode();
      }
      if (Week.HasValue) {
        hash = hash * 23 + .Week.Value.GetHashCode();
      }
      if (Day.HasValue) {
        hash = hash * 23 + obj.Day.Value.GetHashCode();
      }
      return hash;
    }
