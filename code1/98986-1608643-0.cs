    class IntVersion : Base<int> {
      public override int GetName() { return 1; }
      public int GetName(int addNumber) { ... }
    }
    class StringVersion : Base<string> {
      public override string GetName() { return "foo"; }
    }
    class DateTimeVersion : Base<DateTime> {
      public override DateTime GetName() { return DateTime.Now; }
    }
