    public static class DisplayableExtensions {
      public static IDisplayable ToDisplayable(this IEnumerable source) {
        if (source == null) throw new NullReferenceException(); // extension method should behave like instance methods
        var result = new CompositeDisplayable();
        source.
          OfType<IDisplayable>().
          ToList().
          ForEach(displayable => result.Add(displayable));
        return result;
      }
      
    }
