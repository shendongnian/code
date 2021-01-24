    // Helper method to display size and rectangle properties
    private static string GetDisplayValues(Size size, Rectangle rect)
    {
        return $" - size: {size.Width} x {size.Height}\n" +
               $" - rect: {rect.X}, {rect.Y} : {rect.Width} x {rect.Height}\n";
    }
    private static void Main()
    {
        var size = new Size(640, 480);
        var rect = new Rectangle(436, 150, 146, 170);                        
        Console.WriteLine($"Original:\n{GetDisplayValues(size, rect)}");
        var newSize = new Size(800, 600);
        var newRect = GetNewRectangle(size, rect, newSize);
        Console.WriteLine($"Resized:\n{GetDisplayValues(newSize, newRect)}");
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
