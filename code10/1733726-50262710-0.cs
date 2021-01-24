    // in your startup code
    EntityRepository.SaturateEntities();
    ...
    // here is the entity repo
    public class EntityRepository
    {
        public static List<SomeEntity> SomeEntities { get; private set; }
        public static List<SomeOtherEntity> SomeOtherEntities { get; private set; }
        public static void SaturateEntities()
        {
            // _db is assumed to be your entity framework context
            // ToList() will actually execute the query and return the results
            SomeEntities = _db.SomeEntities.ToList();
            SomeOtherEntities = _db.SomeOtherEntities.ToList();
        }
    }
