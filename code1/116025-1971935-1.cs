    public static class MyListUtils {
      public static IEnumerable<Model.objA> ToModel(
         this IEnumerable<Entity.objA> entities)
      {
        return entities.Select(entity => (Model.objA)entity);
      }
    }
