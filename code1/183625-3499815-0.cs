        public static void Main()
        {
            Panda[] forest_panda = new Panda[10];
            for (int i = 0; i < forest_panda.GetLength(0); i++)
                forest_panda[i] = new Panda("P1");
            // Dispose the pandas by your own
            foreach (var panda in forest_panda)
                panda.Dispose();
            for (int i = 0; i < forest_panda.GetLength(0); i++)
                forest_panda[i] = new Panda("P1");
            // Dispose the pandas by your own
            foreach (var panda in forest_panda)
                panda.Dispose();
            Console.WriteLine("Total Pandas created is {0}", Panda.population);
        }
        class Panda : IDisposable
        {
            public static int population = 0;
            public string name;
            public Panda(string name)
            {
                this.name = name;
                population = population + 1;
            }
            ~Panda()
            {
                Dispose(false);
            }
            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            /// <filterpriority>2</filterpriority>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    population = population - 1;
                }
            }
        }
