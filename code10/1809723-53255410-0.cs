    class myclass
    {
        public myclass()
        {
            
        }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Num3 { get; set; }
        public int Num4 { get; set; }
        
        public int result1 => Num1 + Num2;
        public int result2 => Num3 + Num2;
        public int result3 => Num4 + Num2;
    }
