    public abstract class NoResubmitAbstract
    {
        public Guid PreventResubmit { get; set; }
        public void SetPreventResubmit(Guid prs)
        {
            PreventResubmit = prs;
        }
    }
