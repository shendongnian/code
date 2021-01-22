    public interface IMyDictionary
    {
        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, IFoo>.KeyCollection Keys { get; }
        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, IFoo>.ValueCollection Values { get; }
    }
