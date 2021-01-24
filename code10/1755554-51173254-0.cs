    [OracleCustomTypeMapping("EMPMLOY")]
    public class EmployFactory : IOracleCustomTypeFactory
    {
        public IOracleCustomType CreateObject()
        {
            return new Employ();
        }
    }
