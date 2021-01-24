    private void GetDynamicData<T>(IEnumerable<T> list, List<string> fetchFields)
        {
            var fields = $"new ({string.Join(",", fetchFields)})";
            var res = list.AsQueryable().Select(fields);
            //For test only to check the value of selected fields
            foreach (dynamic item in res) {
                Console.WriteLine(item.id_state);
                Console.WriteLine(item.id_country);
            }
        }
OUTPUT
1
IND
2
IND
3
IND
4
IND
