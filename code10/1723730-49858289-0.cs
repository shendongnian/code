        private void Update()
        {
            i.DoSomething();
            i.DestroyComponent();
            if (!i.IsDestroyed) {
               // This will not be called
               i.DoSomething();
            }
        }
