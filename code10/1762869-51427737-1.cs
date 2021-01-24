        internal class WrapperViewModel
        {
            private IVsUIShell uiShell;
            private IServiceProvider _serviceProvider { get; }
    
            public WrapperViewModel(IVsUIShell uiShell, IServiceProvider serviceProvider)
            {
            }        
			
    		//multiple classes
			public NavigationAssistantViewModel NavigationAssistantViewModel { get;set;}
			public MvvmClass2 MvvmClass2 { get;set;}
        }
        //multiple classes		
        private class NavigationAssistantViewModel {
			
        }
        private class MvvmClass2 {
			
        }
        
