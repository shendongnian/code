    protected TRIMBrokerASMXProxy.ASMXProxy.MetaData[]
        CopyMetaData(MetaData[] utilArray)
    {
        TRIMBrokerASMXProxy.ASMXProxy.MetaData[] outArray = 
            new TRIMBrokerASMXProxy.ASMXProxy.MetaData[utilArray.Length];
        for (int i = 0; i < utilArray.Length; i++)
        {
            outArray[i] = new TRIMBrokerASMXProxy.ASMXProxy.MetaData();
            outArray[i].Name = utilArray[i].Name;
            outArray[i].Value = utilArray[i].Value;
        }
        return outArray;
    }
