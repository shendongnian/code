    public static class ListExtensions {
        public static List<Model.objA> ConvertToModel(this List<Entity.objA> entities) {
            return entities.ConvertAll(e => (Model.objA)e);
        }
    }
