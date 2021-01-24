    public class Ages
    {
        public int Age1 { get; set; }
        public int Age2 { get; set; }
        public int Age3 { get; set; }
        public int Age4 { get; set; }
    
        private void UpdateAges()
        {
            this.Age1++;
            this.Age2++;
            this.Age3++;
            this.Age4++;
        }
        private string ToString() => 
            $"Age1 = {this.age1}, Age2 {this.age2}, Age3 = {this.age3}, Age4 {age4}";
    }
