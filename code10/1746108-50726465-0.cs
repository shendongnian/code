    private int CountChars()
            {
                int count = 50;
                Thread.Sleep(5000);
                return count;
            }
    
            private Task<int> CountCharsAsync() // notice no async!
            {
                return Task.Run(CountChars);
            }
