    //Returns source sorted by products
    //Due to usage of the `this` keyword on the `IEnumerable<JObject> source` parameter,
    //this method can be called like a member method on any instance imlpementing `IEnumerable<JObject>`.
    public static class MyProductExtensionMethods {
        public static IEnumerable<JObject> SortByList(this IEnumerable<JObject> source,
                    IEnumerable<JObject> products) {
            foreach(var prod in products) {
                // sorting happens here and assigning the next sorted item
                // to the variable  `sorted_next` (sorting part obviously not provided)
                yield return sorted_next;
            }
        }
    }
