    enum Version {
    	Major = 0,
    	Build = 1,
    	Revision = 2
    }
    public class MyApp {
    	static Dictionary<Version, object> versionManager = new Dictionary<Version, object> {
    		{Version.Major, new Major() },
    		{Version.Build, new Build() },
    		{Version.Revision, new Revision() }
    	};
    
    	public static object Run( int v, XmlDocument xmlDoc ) {
    		try {
    			Version version = (Version)v;
    			var classObj = versionManager[version];
    			return classObj.GetType().GetMethod("Parse").Invoke(classObj, new object[] { xmlDoc });//System.Reflection;
    		} catch {
    			throw new NotImplementedException();
    		}
    	}
    }
    //Major = 0
    class Major {
    	public Major( ) { }
    	public string Parse( XmlDocument xmlDoc ) {
    		return "DONE";
    	}
    }
    //Build = 1
    class Build {
    	public Build( ) { }
    	public string Parse( XmlDocument xmlDoc ) {
    		return "DONE";
    	}
    }
    //Revision = 2
    class Revision {
    	public Revision( ) { }
    	public string Parse( XmlDocument xmlDoc ) {
    		return "DONE";
    	}
    }
    
