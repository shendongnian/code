    public string checkInputParamters(string baseUrl, string owner, string documentId, string user, string secret, string type)
        {
    		return String.IsNullOrEmpty(baseUrl) ? 
    			ExceptionsCodes.BASE_URL_CANNOT_BE_NULL_OR_EMPTY.ToString("g") :
    			( String.IsNullOrEmpty(owner) ? ExceptionsCodes.OWNER_CANNOT_BE_NULL_OR_EMPTY.ToString("g") : "" );
        }
