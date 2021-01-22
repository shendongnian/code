    public interface IThing { void Update(); }
    
    public static class ThingRegistry {
      public static void RegisterThing<T>() where T : IThing { ... }
    
      public static T CreateThing<T>() where T : IThing { ... }
    }
