    public class EFManagerRepository : IManagerRepository
    {
        public IEnumerable<Manager> Managers
        {
            get
            {
                using (LightCRMEntities context = new LightCRMEntities())
                {
                    return context.Managers.Include("ContactDetail").ToList();
                }
            }
        }
    }
