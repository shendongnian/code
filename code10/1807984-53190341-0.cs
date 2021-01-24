    You can create your own extension method on the rectangle that will print out all the details that you . 
    
    Check my example here.
    
     public static class RectangleExtensions
        {
            public static string Details(this System.Drawing.Rectangle rectangle)
            {
                var details = new StringBuilder();
                details.AppendFormat("Height: {0}", rectangle.Height);
                details.AppendFormat("Bottom: {0}", rectangle.Bottom);
                details.AppendFormat("Left: {0}", rectangle.Left);
                details.AppendFormat("Right: {0}", rectangle.Right);
    
                return details.ToString();
            }
        }
        class Program
        {
    
          
            static void Main(string[] args)
            {
                var rectangle = new System.Drawing.Rectangle();
    
    
                Console.WriteLine(rectangle.Details());
            }
        }
