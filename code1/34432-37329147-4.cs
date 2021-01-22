    [OracleCustomTypeMapping(StringListCustomType.Name)]
    public class StringListCustomTypeFactory : IOracleCustomTypeFactory, IOracleArrayTypeFactory
    {
        #region IOracleCustomTypeFactory
        IOracleCustomType IOracleCustomTypeFactory.CreateObject()
        {
            return new StringListCustomType();
        }
        #endregion
        #region IOracleArrayTypeFactory
        Array IOracleArrayTypeFactory.CreateArray(int numElems)
        {
            return new string[numElems];
        }
        Array IOracleArrayTypeFactory.CreateStatusArray(int numElems)
        {
            return new OracleUdtStatus[numElems];
        }
        #endregion
    }
