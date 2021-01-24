    public DataTypeModel<T> GetDataType<T>(string str) where T : class
        {
            List<DataTypeDomain> dataTypeDomain = new List<DataTypeDomain>();
            _dataProvider.ExecuteCmd(
                "config_select_by_key",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@ConfigKey", str);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    int i = 0;
                    DataTypeModel<int> dataTypeModel = new DataTypeModel<int>();
                    string key = string.Format("Key{0}", i);
                    DataTypeDomain dtd = dataTypeDomain.Find(x => x.ConfigKey == key);
                    dataTypeModel.ConfigKey = dtd.ConfigKey;
                    dataTypeModel.ConfigValue = int.Parse(dtd.ConfigValue);
                }
            );
            return new DataTypeModel<T>()
            {
                ConfigKey = "What your key is",
                ConfigValue = dataTypeDomain.First() as T //Supposing that the list only contains one config element , if not, you should change your method return type to a List<DataTypeModel<T>> and return a List doing this for each element.
            };
        }
