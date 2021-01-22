    using ProxyMetaData = TRIMBrokerASMXProxy.ASMXProxy.MetaData;
    ...
    protected ProxyMetaData[] CopyMetaData(MetaData[] utilArray)
    {
        ProxyMetaData[] outArray = new ProxyMetaData[utilArray.Length];
        for (int i = 0; i < utilArray.Length; i++)
        {
            outArray[i] = new ProxyMetaData();
            outArray[i].Name = utilArray[i].Name;
            outArray[i].Value = utilArray[i].Value;
        }
        return outArray;
    }
