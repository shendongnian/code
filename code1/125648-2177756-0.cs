                var dict = new Dictionary<Key, string>
                       {
                           { new Key { KeyType = KeyTypes.KeyTypeA }, "keytype A" },
                           { new Key { KeyType = KeyTypes.KeyTypeB }, "keytype B" },
                           { new Key { KeyType = KeyTypes.KeyTypeC }, "keytype C" }
                       };
            var groupedDict = dict.GroupBy(kvp => kvp.Key.KeyType);
            foreach(var item in groupedDict)
            {
                Console.WriteLine("Grouping for: {0}", item.Key);
                foreach(var d in item)
                    Console.WriteLine(d.Value);
            }
