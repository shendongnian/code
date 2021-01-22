    namespace ConsoleApplication1 {
       class Program {
          static void Main(string[] args) {
             List<int> listIsARefType = new List<int>();
             ModifyIt(listIsARefType);
             ModifyIt(listIsARefType);
             Console.WriteLine(listIsARefType.Count); // 2!
             Console.ReadKey(true);
          }
    
          static void ModifyIt(List<int> l) {
             l.Add(0);
          }
       }
    }
