     public static class Mapper
     {
         public static IEnumerable<ViewModel> ToViewModelList(this IEnumerable<Entity> entities)
         {
              return entities.Select(ToViewModel);
         }
         public static ViewModel ToViewModel(this Entity entity) 
         {
              return new ViewModel() {
                  // Include mapping inside here    
                  Id = entity.Id;
              };
         }
     }
