        public Task<IReadOnlyCollection<string>> ToReadOnlyCollection()
        {
            return ToListAsync().ContinueWith(x => new ReadOnlyCollection<string>(x.Result) as IReadOnlyCollection<string>);
        }
        public Task<IReadOnlyList<string>> ToReadOnlyList()
        {
            // if you don't mind an IReadOnlyList, you can use this
            // one which doesn't involve creating a new collection
            return ToListAsync().ContinueWith(x => x.Result as IReadOnlyList<string>);
        }
        private Task<List<string>> ToListAsync()
        {
            return Task.Run(() =>
            {
                Task.Delay(1000);
                return new List<string>
                {
                    "1",
                    "2",
                    "3"
                };
            });
        }
