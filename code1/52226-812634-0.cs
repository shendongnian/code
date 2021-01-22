    private TimeSpan GetDuration(Action a)
            {
                var start = DateTime.Now;
                a.Invoke();
                var end = DateTime.Now;
                return end.Subtract(start);
            }
            
            public void something()
            {
                string message;
                var timeSpan = GetDuration(() => { message = "Hello"; } );
            }
