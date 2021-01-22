        private Update BuildMetaData(MetaData[] nvPairs)
        {
            Update update = new Update();
            InputProperty[] ip = Array.CreateInstance(typeof(InputProperty), nvPairs.Count()) as InputProperty[];
            int i;
            for (i = 0; i < nvPairs.Length; i++)
            {
                if (nvPairs[i] == null) break;
                ip[i] = new InputProperty();
                ip[i].Name = "udf:" + nvPairs[i].Name;
                ip[i].Val = nvPairs[i].Value;
            }
            update.Items = ip;
            return update;
        }
