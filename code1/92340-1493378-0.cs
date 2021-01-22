    interface IEntity<T> where T : class {
       Expression<Func<T, bool>> FilterQuery(string filter);
    }
    partial class AnEntity : IEntity<AnEntity>
    {
      public string AName {get; set;}
      Expression<Func<AnEntity,bool>> IEntity<AnEntity>.FilterQuery(string filter)
      {
        return x => x.AName.Contains(filter);
      }
    }
