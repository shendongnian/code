    public class MessageBoxStore
    {
        private HashTable store;
        public string Get(string msg)
        {
            if (stock.ContainsKey(msg))
                return stock[msg];
            else
                return string.Empty;
        }
        public string Set(string msg, string msgcontent)
        {
            stock[msg] = msgcontent;
        }
    }
