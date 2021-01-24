    static void Main(string[] args)
    {
        Try{
        Console.Write("Age: ");
        int Age = Convert.ToInt32(Console.ReadLine());
        Console.ReadKey();
        }
        Catch (Exception e){
        Console.writeLine(e)
        }
    }
