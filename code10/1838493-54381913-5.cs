class Rectangle
{
    public double Length { get; set; }
    public double Width { get; set; }
    public double GetArea()
    {
        return Length * Width;
    }
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("Length: " + Length);
        stringBuilder.AppendLine("Width: " + Width);
        stringBuilder.Append("Area: " + GetArea());
        return stringBuilder.ToString();
    }
}
class ExecuteRectangle
{
    static void Main(string[] args)
    {
        Rectangle r = new Rectangle();
        Console.WriteLine("Length= ");
        double.TryParse(Console.ReadLine(), out r.Length);
        
        Console.WriteLine("Width= ");
        double.TryParse(Console.ReadLine(), out r.Width);
        Console.Writeline("Area= " + r.GetArea());
        Console.WriteLine(r.ToString());
        Console.ReadLine();
    }
}
