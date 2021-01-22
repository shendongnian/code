    using System;
    using System.Threading.Tasks;
    
    class Program {
      static void Main(string[] args) {
        var options = new ParallelOptions();
        options.MaxDegreeOfParallelism = 2;
        Parallel.For(0, 100, options, (ix) => {
          //..
        });
      }
    }
