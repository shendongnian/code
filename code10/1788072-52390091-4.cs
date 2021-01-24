    public class MyOwnClass
    {
        public string Prop1 { get; set; }
        public int Prop2 { get; set; }
        public MyOwnClass ShallowClone()
        {
            return (MyOwnClass)MemberwiseClone();
        }
    }
