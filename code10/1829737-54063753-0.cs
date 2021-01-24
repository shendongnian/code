    public abstract class ViewModelBase {
    	public HeaderViewModel Header {get;}
    	public NavigationViewModel Navigation {get;}
    	public FooterViewModel Footer {get;}
    	
    	public ViewModelBase(HeaderViewModel header, NavigationViewModel navigation, FooterViewModel footer) {
    		Header = header;
    		Navigation = navigation;
    		Footer = footer;
    	}
    }
    
    public class HeaderViewModel {
    	// properties
    	
    	public HeaderViewModel(...) {
    	}
    }
    
    public class NavigationViewModel {
    	// properties
    	
    	public NavigationViewModel(...) {
    	}
    }
    
    public class FooterViewModel {
    	// properties
    	
    	public FooterViewModel(...) {
    	}
    }
