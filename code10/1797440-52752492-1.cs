        public void Add(YourOtherClass data )
        {
            (...)
            OnAdd(); // fire and forget
        }
        private void OnAdd()
        {
            Task.Run(() =>
            {
                CleanUp();
            }).ConfigureAwait(false);
        }
