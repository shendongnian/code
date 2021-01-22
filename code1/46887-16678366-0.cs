    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public uint ID { get; set; }
        public string[] ToListViewItem()
        {
            return new string[] {
                ID.ToString("000000"),
                Name,
                Address,
                DOB.ToShortDateString()
            };
        }
    }
