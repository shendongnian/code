    public class FundBalance
    {   
    		private long _Id;
    		public virtual long Id
    		{
    			get { return _Id; }
    			set { _Id = value; }
    		}
    		private decimal _FundBalance;
    		public virtual decimal FundBalance
    		{
    			get { return _FundBalance; }
    			set { _FundBalance= value; }
    		}
    
    		private string _FundName;
    		public virtual string FundName
    		{
    			get { return _FundName; }
    			set { _FundName= value; }
    		}
    }
