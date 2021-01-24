    var dict = new ConcurrentDictionary<string, string>(100, userList.Count);
            
            userList.AsParallel().ForAll(item => 
            {
                dict.AddOrUpdate(ToAddress(item), item);
            });
            enterpriseUserList.AsParallel().ForAll(x =>
            {
                if (dict.ContainsKey(x))
                { Console.WriteLine(dict[x]); }
            });
