    using System;
    class Program
    {
    static void Main(string[] args)
    {
    Console.ForegroundColor = ConsoleColor.Red;
    int calcKelvin = 273;
    int calcFahren = 32; 
    int result;
    bool isNum=int.TryParse(Console.ReadLine(),out result);
    if (!isNum)
    {
        Console.Write("Error, you can not convert a text");
    }
    else if (result == 0)
    {
        Console.WriteLine("Check it up on google!");
        Console.Title = "I'M USELESS CONSOLE, YOU CAN NOW EXIT || I'M USELESS CONSOLE, YOU CAN NOW EXIT || I'M USELESS CONSOLE, YOU CAN NOW EXIT ||";
    }
    else { 
    Console.WriteLine("Kelvin = " + calcKelvin * result);
    Console.WriteLine("Fahrenheit = " + calcFahren * result);
    }
    }
    }
