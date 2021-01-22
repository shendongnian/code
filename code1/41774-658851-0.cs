    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.Windows.Forms;
    
    namespace InstallHelper
    {
    	[RunInstaller(true)]
    	public partial class PostInstallActions : Installer
    	{
    		public PostInstallActions()
    		{
    			InitializeComponent();
    		}
    
    		public override void Install(IDictionary state)
    		{
    			base.Install(state);
    			// Do my custom install actions
    		}
    
    		public override void Commit(IDictionary state)
    		{
    			base.Commit(state);
    			// Do my custom commit actions
    		}
    
    		public override void Uninstall(IDictionary state)
    		{
    			base.Uninstall(state);
    			// Do my custom uninstall actions
    		}
    	}
    }
