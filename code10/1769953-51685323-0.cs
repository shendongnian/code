    using System;
    public class Calculator{
    public int Addition(int a, int b){
    int sum = a+b;
    return sum;
    }
    public int Subtraction(int a, int b){
    int diff = a-b;
    return diff;
    }
    public int Multiplication(int a, int b){
    int mul = a*b;
    return mul;
    }
    public double Division(int a, int b, out double remainder){
    double div = a/b;
    double rem = a%b;
    remainder = rem;
    return div;
    }
    }
    public class program{
    public static void Main(){
    double remainder;
    Calculator c  = new Calculator();
    Console.WriteLine("Enter the operator");
    char s=Convert.ToChar(Console.ReadLine());
    Console.WriteLine("Enter the operands");
    int a=Convert.ToInt32(Console.ReadLine());
    int b=Convert.ToInt32(Console.ReadLine());    
    switch(s)
    {
    case '+':
    int summ = c.Addition(a,b);
    Console.WriteLine("Result of {0} + {1} is {2}",a,b,summ);
    break;
    case '-':
    int sub = c.Subtraction(a,b);
    Console.WriteLine("Result of {0} - {1} is {2}",a,b,sub);
    break;
    case'*':
    int mul = c.Multiplication(a,b);    
    Console.WriteLine("Result of {0} * {1} is {2}",a,b,mul);
    break;
    case '/':
    double div = c.Division(a,b,out remainder);
    Console.WriteLine("Result of {0} / {1} is {2} and rem is {3}",a,b,div,remainder);
    break;
    default:
    Console.WriteLine("Invalid Operand");
    break;
    }
    }
    }
