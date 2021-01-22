    // enum definition
    	public enum EFeedType {
    		TypeOne = 1,
    		TypeTwo = 2,
    	}
    
    // usage
    		private void TestEnum() {
    			Int32 feedId = 2;
    			EFeedType stuff = (EFeedType)Enum.Parse(typeof(EFeedType), feedId.ToString());
    			Response.Write(stuff.ToString());
    		}
