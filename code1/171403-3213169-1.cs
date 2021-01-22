    public class Foo : ISelectEntity<StatusCodes, StatusCodesInputParameters>
    {
        public List<StatusCodes> GetFromDB(StatusCodesInputParameters data)
        {
            return EntitiesClass.PopulateStatusCodes(EntitiesDAL.GetStatusCodes(data));
        }
    }
