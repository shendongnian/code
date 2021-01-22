    import static Element.ElementDict;
    
    public class Element {
		// .... 
    	private static readonly Dictionary<string, object> elemDict = new Dictionary<string, object>();
    	public class ElementDict {
    		public readonly static ElementDict element = new ElementDict();
    		public object this[string key] {
    			get => elemDict.TryGetValue(key, out object o) ? o : null;
    			set => elemDict[key] = value;
    		}
    	}
    }
