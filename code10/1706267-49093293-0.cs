    public class FirstViewModel
    {
        public int Id { get; set; }
        public string Prop2 { get; set; }
        public DateTime Prop3 { get; set; }
    }
    
    public class SecondViewModel
    {
        public int Id { get; set; }
        public string Prop2 { get; set; }
        public int Prop3 { get; set; }
    }
    
    public class ThirdFormViewModel
    {
        public FirstViewModel FirstModel { get; set; }
        public SeconViewdModel SecondModel { get; set; }
    }
