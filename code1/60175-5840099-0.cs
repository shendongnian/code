    public class Data
    {
        public int IntData { get; set; }
        public string StringData { get; set; }
        public DateTime[] DataTimeArrayData { get; set; }
        public MultiReturnValueHelper<int, string, DateTime[]> GetData()
        {
            return new MultiReturnValueHelper<int, string, DateTime[]>(
                this.IntData, 
                this.StringData, 
                this.DataTimeArrayData);
        }
    }
