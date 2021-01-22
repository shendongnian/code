	using System.Runtime.InteropServices;
	using System.Windows.Forms;
	using ServiceLibrary;
	using IServiceProvider=ServiceLibrary.IServiceProvider2;
	
	namespace COMInterfaceTester
	{
	    [ComVisible(true)]
	    [Guid("2B9D06B9-EB59-435e-B3FF-B891C63108B2")]
	    public interface INewService : IService
	    {
	        string ServiceName { get; }
	    }
	
	    [ComVisible(true)]
	    [Guid("2B9D06B9-EB59-435e-B3FF-B891C63108B3")]
	    public class NewService : INewService
	    {
	        public string _name;
	
	        public NewService(string name)
	        {
	            _name = name;
	        }
	
	        //  implement interface
	        #region IService Members
	
	        public void DoSomething()
	        {
	            MessageBox.Show("NewService.DoSomething");
	        }
	
	        #endregion
	
	        public string ServiceName
	        {
	            get { return _name; }
	        }
	    }
	
	    [ComVisible(true)]
	    [Guid("2B9D06B9-EB59-435e-B3FF-B891C63108B4")]
	    public interface INewProvider : IServiceProvider
	    {
	        //  adds nothing, just implements
	    }
	
	    [ComVisible(true)]
	    [Guid("2B9D06B9-EB59-435e-B3FF-B891C63108B5")]
	    public class NewProvider : INewProvider
	    {
	        //  implement interface
	        public void Init(object sink, ref bool result)
	        {
	            MessageBox.Show("NewProvider.Init");
	        }
	
	        public void GetService(int serviceIndicator, ref IService result)
	        {
	            result = new NewService("FooBar");
	            MessageBox.Show("NewProvider.GetService");
	        }
	    }
	}    
	    
      
