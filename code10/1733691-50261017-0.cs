    static class ListTest
    {
        static List<string> _list; // Static List instance
        static ListTest()
        {
            _list = new List<string>();
        }
        public static void AddNewThingToList(Activity activity)
        {
            _list.Add(Parser.GetAfterCommandText(activity));
        }
        public static void ShowList()
        {
            var response = new StringBuilder();
            for (var i = 0; i < _list.Count; i++)
            {
                response.Append($"{i}. {_list[i]}{Environment.NewLine}");
            }
		    return response;
        }
    }
