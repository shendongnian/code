    static void Main(string[] args)
    {
       pay[] myPay = new pay[3];
       for (int i = 0; i <= 2; i++)
       {
          Console.WriteLine("Enter name: ");
          myPay[i].name = Console.ReadLine();
          Console.WriteLine("Enter pay rate: ");
          myPay[i].rate = Convert.ToInt16(Console.ReadLine());
          Console.WriteLine("Enter hours worked: ");
          myPay[i].hours = Convert.ToInt16(Console.ReadLine());
       }
       Console.WriteLine("Name\tRate\tHours\tGross\t W/T\tSS\tMed\tNet");
       for (int i = 0; i <= 2; i++)
       {
          myPay[i].Calculate();
          Console.WriteLine($"{myPay[i] .name}\t{myPay[i] .rate}\t{myPay[i] .hours}\t{myPay[i] .gross}\t{myPay[i] .wtd}\t{myPay[i] .ssd}\t{myPay[i] .md}\t{myPay[i] .net}");
       }
       Console.ReadLine();
    }
