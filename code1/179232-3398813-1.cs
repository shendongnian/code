    public class Organism : IDisposable
    {
        public static List<Organism> All = new List<Organism>();
        private bool disposed = false;
        public Organism()
        {
            Organism.All.Add(this);
        }
        public void BeBorn()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Organism.All.Remove(this);
                }
                disposed = true;
            }
        }
        ~Organism()
        {
            Dispose(false);
        }
    }
