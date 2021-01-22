    class Program
    {
        static void Main(string[] args)
        {
            classC c = new classC();
            c.Dispose();
        }
    }
    class classA: IDisposable 
    { 
        private bool m_bDisposed;
        protected virtual void Dispose(bool bDisposing)
        {
            if (!m_bDisposed)
            {
                if (bDisposing)
                {
                    // Dispose managed resources
                    Console.WriteLine("Dispose A"); 
                }
                // Dispose unmanaged resources 
            }
        }
        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Console.WriteLine("Disposing A"); 
        } 
    } 
 
    class classB : classA, IDisposable 
    {
        private bool m_bDisposed;
        public void Dispose()
        {
            Dispose(true);
            base.Dispose();
            GC.SuppressFinalize(this);
            Console.WriteLine("Disposing B");
        }
        protected override void Dispose(bool bDisposing)
        {
            if (!m_bDisposed)
            {
                if (bDisposing)
                {
                    // Dispose managed resources
                    Console.WriteLine("Dispose B");
                }
                // Dispose unmanaged resources 
            }
        }
    } 
 
    class classC : classB, IDisposable 
    {
        private bool m_bDisposed;
        public void Dispose() 
        {
            Dispose(true);
            base.Dispose();
            GC.SuppressFinalize(this);
            Console.WriteLine("Disposing C");             
        }
        protected override void Dispose(bool bDisposing)
        {
            if (!m_bDisposed)
            {
                if (bDisposing)
                {
                    // Dispose managed resources
                    Console.WriteLine("Dispose C");             
                }
                // Dispose unmanaged resources 
            }
        }
    } 
 
}
