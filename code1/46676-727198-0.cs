    public class Event
    {
      public string Day; 
    }
    
    [Test]
    public void Te()
    {
      var dayIndex = new List<string> {"MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY"};
      var list = new List<Event> {new Event(){Day = "saturday"}, new Event() {Day = "Monday"}, new Event() {Day = "Tuesday"}};
      var sorted = list.OrderBy(e => dayIndex.IndexOf(e.Day.ToUpper()));
      foreach (var e in sorted)
      {
        Console.WriteLine(e.Day);
      }
    }
