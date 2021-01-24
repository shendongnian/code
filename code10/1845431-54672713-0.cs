    internal class _iData
    {       
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Shelf { get; set; }
        public string Quantiy { get; set; }
    }
    
    public static class DataProvider 
    {
        private static _iData _data;
        public static _iData ItemData { get {return this._data;} }
        
        public static void Deserialize(string json) 
        {
            this._data =js.Deserialize<_iData>(objText)
        }
    }
    
    DataProvider.Deserialize(objText);
