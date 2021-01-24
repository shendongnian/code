    using System;
    using System.Windows.Input;
    using Microsoft.VisualStudio.Shell.Interop;
    
    namespace NavigationAssistant
    {
		
        internal class WrapperViewModel
        {
            private IVsUIShell uiShell;
    
            private IServiceProvider _serviceProvider { get; }
    
            public WrapperViewModel(IVsUIShell uiShell, IServiceProvider serviceProvider)
            {
                this.uiShell = uiShell;
                this._serviceProvider = serviceProvider;
            }
    
            private ICommand changeThemeCommand;
    
            public ICommand ChangeThemeCommand
            {
                get
                {
                    return this.changeThemeCommand ?? (this.changeThemeCommand = new VSCommand(this._serviceProvider, this.uiShell));
                }
            }
			
    		//multiple classes
			public MvvmClass1 MvvmClass1 { get;set;}
			public MvvmClass2 MvvmClass2 { get;set;}
       }
		
		public class MvvmClass1 {
			
		}
		public class MvvmClass2 {
			
		}
    }
