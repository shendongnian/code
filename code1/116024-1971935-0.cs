    public static class MyListUtils {
      public static List<Model.objA> ToModel(this List<Entity.objA> entities)
      {
        return entities.ConvertAll(entity => (Model.objA)entity);
      }
    }
