    public class HasTwoNames : IHasName2
    {
        #region IHasName1 Member
        public string Name1 { get; set; }
        #endregion
        #region IHasName2 Member
        public string Name2 {get; set; }
        #endregion
    }
