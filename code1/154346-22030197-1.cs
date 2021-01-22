    using System.Reflection;
    
    public class Outer {
    	private delegate void _operateDlg(Inner inner, bool value);
    	private static _operateDlg _validate;
    
    	static Outer() {
    		typeof(Inner).GetMethod("Init",
    			BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
    	}
    
    	public void Set(Inner inner, bool value) {
    		_validate(inner, value);
    	}
    
    	public class Inner {
    		public bool IsValid {get; private set; }
    		private static void Init() {
    			Outer._validate = delegate(Inner i, bool value) {
    				i.IsValid = value;
    			};
    		}
    	}
    }
