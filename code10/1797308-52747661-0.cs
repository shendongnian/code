        public delegate TValue GetNewValue<TValue>(TValue previousValue);
        public interface IIntStringAtomicDictionary
        {
            /// <returns>true if was added, otherwise false</returns>
            bool AddIfMissingOnly(int key, Func<string> valueGetter);
            /// <returns>true if was updated, otherwise false</returns>
            bool UpdateIfExists(int key, GetNewValue<string> convertPreviousValueToNew);
        }
