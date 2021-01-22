    /// <summary>
    /// This interface is used to implement IsNew in all LINQ objects so a Generic Save method 
    /// can be used.
    /// </summary>
    public interface IDataObject
    {
    
        #region Properties
            #region IsNew
            /// <summary>
            /// Is this a new object
            /// </summary>
            bool IsNew
            {
                get;
            } 
            #endregion
        
        #endregion
        
    } 
    #endregion
