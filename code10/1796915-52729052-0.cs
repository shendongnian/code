    public bool IsValid(out IDictionary<string, string> errors)
    {
    	errors = new Dictionary<string, string>();
    	if (string.IsNullOrWhiteSpace(CaseNumber) && string.IsNullOrWhiteSpace(RitNumber) &&
    		string.IsNullOrWhiteSpace(ApilNumber))
    	{
    		errors.Add("MyError", "At least one Case, Rit or Apil number is required.");
    	}
    	return errors.Count == 0;
    }
