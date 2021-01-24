    class MyClass : IDisposable
    {
        public Image Image { get; }
        public MyClass(byte[] byteArray)
        {
            using (var stream = new MemoryStream(byteArray))
            using (var img = Image.FromStream(stream))
            {
                Image = new Bitmap(img);
            }
        }
        public void Dispose() { ... }
        public virtual void Dispose(bool disposing) { ... }
    }
