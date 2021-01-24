    public class SupportDataRepository<T> where T : SupportDataModel
    {
        public List<T> ListItems()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Set<T>().Where(x => !x.Deleted).ToList();
            }
        }
    }
