    class Updater : IDisposable
    {
        Action<object> setter;
        public Updater(Action<object> setter)
        {
            this.setter = setter;
        }
        public Dispose()
        {
            setter(new object());
        }
    }
