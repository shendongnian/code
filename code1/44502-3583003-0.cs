    public class DefaultDateAttribute : DefaultValueAttribute {
      public DefaultDateAttribute(short yearoffset)
        : base(DateTime.Now.AddYears(yearoffset).Date) {
      }
    }
