    public class PersonBuilder
    {
        public List<PersonRecord> GetPeople()
        {
            IQueryable<PersonRecord> query = DbContext.PersonRecord;
    
            var data = query.Select(asset => new Asset
            {
               data1 = PersonRecord.data1,
               data2 = PersonRecord.data2,
               // other stuff
    
            }).ToList();
    
            return data;
        }
    }
