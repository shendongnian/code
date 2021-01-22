    class IFoo
    { }
    interface MyDictionary
    {
        ICollection<string> Keys { get; }
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<IFoo> Values { get; }
    }
    class IStuff : Dictionary<string, IFoo>, MyDictionary
    {
        #region MyDictionary Members
        //Note the new keyword.
        public new ICollection<string> Keys
        {
            get { throw new NotImplementedException(); }
        }
        public new IEnumerable<IFoo> Values
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
