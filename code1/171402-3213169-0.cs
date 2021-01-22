    public class Foo : ISelectEntity<StatusCodes, StatusCodesInputParameters>
    {
        List<StatusCodes> ISelectEntity<StatusCodes, StatusCodesInputParameters>.GetFromDB(StatusCodesInputParameters data)
        {
            return EntitiesClass.PopulateStatusCodes(EntitiesDAL.GetStatusCodes(data));
        }
    }
