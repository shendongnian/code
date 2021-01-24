    public class Csv<T> : List<T> where T : IConvertible
    {
        public Csv<T> Append(string delimitedValues)
        {
            var splitValues = delimitedValues
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Cast<string>();
            var convertedValues = splitValues
                .Select(str => Convert.ChangeType(str, typeof(T)))
                .Cast<T>();
            this.AddRange(convertedValues);
            return this;
        }
        
        public override string ToString()
        {
            return this.Aggregate("", (a,s) => $"{a},{s}").Trim(',');
        }
    }
