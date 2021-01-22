    		public List<string> FindKeywords(string emailbody, List<string> keywordList)
    		{
    			// may want to clean up the input a bit, such as replacing '.' and ',' with a space
    			// and remove double spaces
    
    			string emailBodyAsUppercase = emailbody.ToUpper();
    
    			List<string> emailBodyAsList = new List<string>(emailBodyAsUppercase.Split(' '));
    
    			List<string> foundKeywords = new List<string>(emailBodyAsList.Intersect(keywordList));
    			
    
    			return foundKeywords;
    		}
