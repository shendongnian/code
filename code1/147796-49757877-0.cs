    public class ClassThatWillBeASingleton
    {
        private ClassThatWillBeASingleton()
        {
            Thread.Sleep(20);
            guid = Guid.NewGuid();
            Thread.Sleep(20);
        }
        public Guid guid { get; set; }
    }
