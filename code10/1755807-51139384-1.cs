    var dict = new ConcurrentDictionary<string, string>(100, userList.Count);
            
            userList.AsParallel().ForAll(item => 
            {
                dict.AddOrUpdate(ToAddress(item), item, (key,value)=>{return value;});
            });
            enterpriseUserList.AsParallel().ForAll(x =>
            {
                if (dict.ContainsKey(x))
                { Console.WriteLine(dict[x]); }
            });
