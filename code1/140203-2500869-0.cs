    public abstract class AccessorForSQL: GenoTip.DAL._AccessorForSQL
    {
        public bool Save(string Name, string SurName, string Adress)
        {
            ListDictionary ld = new ListDictionary();
            ld.Add("@Name", Name);
            ld.Add("@SurName", SurName);
            ld.Add("@Adress", Adress);
            return Save("sp_InsertCustomers", ld, CommandType.StoredProcedure);
        }
    }
