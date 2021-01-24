    namespace AddressInq
    {
        class Program
        { 
         
           static void Main(string[] args)
           {
               Console.WriteLine("Please enter the address: ");
               QRmaker.Program.codeMake(Console.ReadLine());
           }
        }
    }
