    public class ArgumentPathResult {
    	public string Path;
    	public List<string> Arguments = new List<string>();
    }
    // Define other methods and classes here
    public static class ArgumentPathParser {
    	public static ArgumentPathResult ParsePath(string path) {
    	    ArgumentPathResult result = new ArgumentPathResult();
    		string resultString = "";
    		foreach(char c in path){
    			resultString += c;
    			if(resultString.Contains(".exe")){
    				break;
    			}
    		}
    		result.Path = resultString;
    		result.Arguments = path.Replace(resultString, "")
    			.Split('-')
			    .Skip(1)
			    .ToList();
    		return result;
    	}
    }
