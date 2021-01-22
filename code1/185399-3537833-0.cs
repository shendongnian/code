    class ArrayContainer
    {
        public byte[] Array1 { get; set; }
        public byte[] Array2 { get; set; }
        public ArrayContainer DeepCopy()
        {
            ArrayContainer result = new ArrayContainer();
            foreach (var property in this.GetType().GetProperties())
            {
                var oldData = property.GetValue(this, null) as byte[];
                if (oldData != null)
                {
                    // Copy data with .ToArray() actually copies data.
                    property.SetValue(result, oldData.ToArray(), null);
                }
            }
            return result;
        }
    }
