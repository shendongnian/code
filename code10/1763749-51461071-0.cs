    class Foo : IDisposable
    {
        public RegistryKey Key { get; set; }
        public void Dispose()
        {
            Key?.Dispose();
        }
    }
