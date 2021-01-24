    class Program {
        static void Main(string[] args) {
            Bootstrapper bootstrapper = new Bootstrapper();
            var kernel = bootstrapper.Init();
            WithQuartz(kernel).GetAwaiter().GetResult();
            Console.ReadKey();
        }
        public static Task WithQuartz(IKernel kernel) {
            var service = kernel.Get<IService>();
            return service.Start();
        }
    }
