        private Update BuildMetaData(MetaData[] nvPairs)
        {
            Update update = new Update();
            List<InputProperty> ip = new List<InputProperty>();
            for (int i = 0; i < nvPairs.Length; i++)
            {
                if (nvPairs[i] == null) break;
                ip[i] = new InputProperty();
                ip[i].Name = "udf:" + nvPairs[i].Name;
                ip[i].Val = nvPairs[i].Value;
            }
            update.Items = ip.ToArray();
            return update;
        }
