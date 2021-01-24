    class A
    {
        static readonly int[] SomeArrayDefaultValue = new int[] { 4, 6, 12 };
		// Disable global settings for NullValueHandling and DefaultValueHandling
        [JsonProperty(NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Include)]
        public int[] SomeArray = (int[])SomeArrayDefaultValue.Clone();
        public bool ShouldSerializeSomeArray()
        {
            return !(SomeArray != null && SomeArray.SequenceEqual(SomeArrayDefaultValue));
        }
    }
