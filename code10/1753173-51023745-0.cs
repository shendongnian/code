    //Returns source sorted by products
    public static class MyProductExtensionMethods {
        public static IEnumerable<JObject> SortByList(this IEnumerable<JObject> source,
                    IEnumerable<JObject> products) {
            foreach(var prod in products) {
                // sorting happens here and assigning the next sorted item
                // to the variable  `sorted_next`
                yield return sorted_next;
            }
        }
    }
