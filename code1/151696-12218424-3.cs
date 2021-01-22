    public partial class GenericResult
    {
    	public IList<string> Errors { get; set; }
        decimal Value { get; set; }
    
    	public GenericResult() 
        {
            this.Errors = new List<string>();
        }
    
        public bool Success
        {
            get { return (this.Errors.Count == 0); }
        }
    
        public void AddError(string error) 
        {
            this.Errors.Add(error);
        }
    }
