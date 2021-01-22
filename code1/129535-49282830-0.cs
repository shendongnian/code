    public class Toolz {
        public static System.Threading.Tasks.Task<object> SetTimeout(Func<object> func, int secs) {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(secs));
            return System.Threading.Tasks.Task.Run(() => func());
        }
    }
    
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(DateTime.Now);
            Toolz.SetTimeout(() => {
                Console.WriteLine(DateTime.Now);
                return "";
            }, 10);
        }
    }
