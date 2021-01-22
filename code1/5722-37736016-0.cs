    public partial class Root : ICloneable
    {
        public Root(int number)
        {
            _number = number;
        }
        private int _number;
    
        public Partial[] Partials { get; set; }
    
        public IList<ulong> Numbers { get; set; }
    
        public object Clone()
        {
            return Clone(true);
        }
    
        private Root()
        {
        }
    } 
    
    public partial class Root
    {
        public Root Clone(bool deep)
        {
            var copy = new Root();
            // All value types can be simply copied
            copy._number = _number; 
            if (deep)
            {
                // In a deep clone the references are cloned 
                var tempPartials = new Partial[Partials.Length];
                for (var i = 0; i < Partials.Length; i++)
                {
                    var value = Partials[i];
                    value = value.Clone(true);
                    tempPartials[i] = value;
                }
                copy.Partials = tempPartials;
                var tempNumbers = new List<ulong>(Numbers.Count);
                for (var i = 0; i < Numbers.Count; i++)
                {
                    var value = Numbers[i];
                    tempNumbers.Add(value);
                }
                copy.Numbers = tempNumbers;
            }
            else
            {
                // In a shallow clone only references are copied
                copy.Partials = Partials; 
                copy.Numbers = Numbers; 
            }
            return copy;
        }
    }
