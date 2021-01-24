    // Given a simple Person interface
    public interface Person {
      int Age { get; }
      string Name{ get; }
    }
    // And a sample data frame with some data
    Frame<int, string> df = Frame.FromValues(new[] {
        Tuple.Create(1, "Name", (object) "One"),
        Tuple.Create(2, "Name", (object) "Two"),
        Tuple.Create(1, "Age", (object) 42),
        Tuple.Create(2, "Age", (object) 21)
      });
    // You can get an array of rows using 
    var rows = df.GetRowsAs<Person>();
