    namespace ConsoleApp
    {
        public static class Extensions
        {
            public static string FromDictionaryToJson(this Dictionary<string, string> dictionary)
            {
                var kvs = dictionary.Select(kvp => string.Format("\"{0}\":\"{1}\"", kvp.Key, string.Concat(",", kvp.Value)));
                return string.Concat("{", string.Join(",", kvs), "}");
            }
    
            public static Dictionary<string, string> FromJsonToDictionary(this string json)
            {
                string[] keyValueArray = json.Replace("{", string.Empty).Replace("}", string.Empty).Replace("\"", string.Empty).Split(',');
                return keyValueArray.ToDictionary(item => item.Split(':')[0], item => item.Split(':')[1]);
            }
        }
        class Program
        {   
            static void Main(string[] args)
            {
    
                using (var clientContext = new ClientContext("http://sp:12001/"))
                {
                    #region MyRegion
                    List list = clientContext.Web.Lists.GetByTitle("Users");                
                    CamlQuery query = new CamlQuery();
                    query.ViewXml = "<View><Query><Where><Geq><FieldRef Name='ID'/>" +
                     "<Value Type='Number'>1</Value></Geq></Where></Query><RowLimit>100</RowLimit><ViewFields><FieldRef Name='ID'/><FieldRef Name='Title'/></ViewFields></View>";
                    
                    var items = list.GetItems(query);
    
                    clientContext.Load(items, eachItem => eachItem.Include(
                    item => item.FieldValuesAsText));               
                    clientContext.ExecuteQuery();
                    foreach (ListItem oListItem in items)
                    {
                        var values = oListItem.FieldValuesAsText.FieldValues as Dictionary<string, string>;
                        Console.WriteLine(Extensions.FromDictionaryToJson(values));
                    }
                    Console.WriteLine(items.Count);
                    #endregion
                    Console.ReadKey();
    
                }
            }
        }
    }
