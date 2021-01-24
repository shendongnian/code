    class CustomEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string left, string right)
        {
    		return right.StartsWith($"ax_{left}");
        }
    
        public int GetHashCode(string str)
        {
            return 0;
        }
    }
