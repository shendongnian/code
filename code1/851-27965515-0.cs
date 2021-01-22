    class MySequence<TElement>
    {
      public IEnumerable<TElement> String { get; set; }
      void Example()
      {
        var test = String.Format("Hello {0}.", DateTime.Today.DayOfWeek);
      }
    }
