        static void Main()
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Load(new DefaultModule());
                kernel.Get<Ninja>().BrutalKill();
            }
        }
