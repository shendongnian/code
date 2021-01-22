    public enum FizzBuzz {
    	Fizz,
    	Buzz,
    	FizzBuzz
    }
    
    public static class EnumExtension {
    	public static void SwitchCase ( this FizzBuzz enm , params KeyValuePair<FizzBuzz , Action> [] parms ) {
    		foreach ( var kvp in parms ) {
    			if ( kvp.Key == enm ) {
    				kvp.Value();
    			}
    		}
    	}
    }
