        static Dictionary<TKey, TValue> NewDictionary<TKey, TValue>(TKey key, TValue value)
        {
            return new Dictionary<TKey, TValue>();
        }
        public void DictRun()
        {
           
            var myDict = NewDictionary(new { url="a"},
                new { Text = "dollar", Url ="urlA"});
            myDict.Add(new { url = "b" }, new { Text = "pound", Url = "urlB" });
            myDict.Add(new { url = "c" }, new { Text = "rm", Url = "urlc" });
            foreach (var k in myDict)
            {
                var url= k.Key.url;
                var txt= k.Value.Text;
                Console.WriteLine(url);
                Console.WriteLine(txt);    
            }
       
        }
