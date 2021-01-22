    abstract class Field
    {
        public int Length { get; set; }
    }
    public class FieldA : Field
    {
        public static void DoSomething()
        {
            Console.WriteLine("Did something.");
        }
    }
