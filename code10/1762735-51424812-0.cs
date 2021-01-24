    public interface IBaseEntity
    {
        int Id{get; set;}
        string Name { get; set;}
        bool IsActive { get; set; }
    }
    public class QueryColumnMapper<T>
      Where T : IBaseEntity
    {
           Dictionary<string, Expression<Func<T, object>>> columnsMap = new Dictionary<string, Expression<Func<T, object>>>
           {
                ["id"] = v => v.Id,
                ["name"] = v => v.Name,
                ["isActive"] = v => v.IsActive
           };
    }
