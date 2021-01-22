    public interface IID
    {
        int ID
        {
            get; set;
        }
    }
    public static class Utils
    {
        public static int GetID<T>(ObjectQuery<T> items) where T:EntityObject, IID
        {
            if (items.Count() == 0) return 1;
            return items.OrderByDescending(u => u.ID).FirstOrDefault().ID + 1;
        }
    }
