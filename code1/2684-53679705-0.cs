     public class Program
        {
            public enum Color : int
            {
                Blue = 0,
                Black = 1,
                Green = 2,
                Gray = 3,
                Yellow =4
            }
    
            public static void Main(string[] args)
            {
                //from string
                Console.WriteLine((Color) Enum.Parse(typeof(Color), "Green"));
                
                //from int
                Console.WriteLine((Color)2);
                
                //From number you can also
                Console.WriteLine((Color)Enum.ToObject(typeof(Color) ,2));
            }
        }
