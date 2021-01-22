    ProxyMetaData[] output = Array.ConvertAll(input, delegate(MetaData metaData)
    {
        ProxyMetaData proxy = new ProxyMetaData();
        proxy.Name = metaData.Name;
        proxy.Value = metaData.Value;
    });
