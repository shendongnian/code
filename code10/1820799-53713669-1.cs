    public static partial class CMEntityBaseExtensions
    {
        public static IQueryable<T> GetByName<T>(this IQueryable<T> Entities, string Name, bool Active = true) where T : CMEntityBase
        {
            return Entities.Where(ss => ss.Name == Name && ss.Active == Active || Active == false).
                     Select(e => e as T); // cast back to child!
        }
    }
