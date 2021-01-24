    public class PersonViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
        // Note the use of nullables here
        public int? NumberOfGoodDeeds { get; set; }
        public int? NumberOfBadDeeds { get; set; }
    } 
