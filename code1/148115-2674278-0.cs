    public class SpecialNameDictionary : Dictionary<string, string>
    {
        /// <param name="specialName">That Special Name</param>
        public new string this[string specialName]
        {
            get
            {
                return base[specialName];
            }
        }
    }
