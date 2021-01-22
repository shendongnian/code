    using Mono.Unix.Native;
    public class Program
    {
        public static void Main()
        {
            if (Syscall.getuid() == 0) {
                System.Console.WriteLine("I'm running as root!");
            } else {
                System.Console.WriteLine("Not root...");
            }
        }
    }
