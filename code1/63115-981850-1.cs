    public class Caster
    {
        public enum DayOfWeek
        {
            Sunday = 0,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }
    
        public Caster() {}
        public Caster(string[] data) { this.Data = data; }
    
        public string this[DayOfWeek dow]{
            get { return this.Data[(int)dow]; }
        }
    
        public string[] Data { get; set; }
    
    
        public static implicit operator string[](Caster caster) { return caster.Data; }
        public static implicit operator Caster(string[] data) { return new Caster(data); }
    
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Caster message_array = new string[7];
            Console.Write(message_array[Caster.DayOfWeek.Sunday]);
        }
    }
