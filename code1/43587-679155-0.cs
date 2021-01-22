    using ProxyMetaData = TRIMBrokerASMXProxy.ASMXProxy.MetaData;
    ProxyMetaData[] convertedArray = Array.ConvertAll<MetaData, ProxyMetaData>(utilArray, 
	delegate(MetaData metaData)
	{
		ProxyMetaData returnValue = new ProxyMetaData();
		returnValue.Name = metaData.Name;
		returnValue.Value = metaData.Value;
		return returnValue;
	});
