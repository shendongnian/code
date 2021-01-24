        public T TryTake(int timeoutMiliseconds)
        {
            var result = default(T);
            if (!_collection.TryTake(out result, timeoutMiliseconds) 
                && !_collection.IsAddingCompleted)
            {
                throw new InvalidOperationException("Unable to get item from collection.");
            }
            return result;
        }
