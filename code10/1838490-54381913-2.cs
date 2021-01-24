class ExecuteRectangle
{
    static void Main(string[] args)
    {
        Rectangle r = new Rectangle();
        Console.WriteLine("Length= ");
        double.TryParse(Console.ReadLine(), out r.length);
        
        Console.WriteLine("Width= ");
        double.TryParse(Console.ReadLine(), out r.width);
        Console.Writeline("Area= ");
        r.Display();
        Console.ReadLine();
    }
}
