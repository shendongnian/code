    public class Product
    {
        private string _description;
        public int Id { get; set; }
        public string Description
        {
            get
            {
                return _description.Replace("\r\n", "\n");
            }
            set
            {
                _description = value;
            }
        }
    }
