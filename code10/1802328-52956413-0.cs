    class Class
    {
            public Class(IIndex<DataType, ITestItem> list)
            {
                //Throws error if you try to get the instance for unregistered key
                var test = list[DataType.Type2];
            }
    }
