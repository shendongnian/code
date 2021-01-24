      using System.IO;
      using System.Linq;
      
      ...
      public static void Main() {
        ...
        Console.Write("The prime numbers between {0} and {1} are : \n",stno,enno);
        File.WriteAllLines(@"c:\MyFile.txt", Primes(stno, enno)
          .Select(value => value.ToString()));
      }
