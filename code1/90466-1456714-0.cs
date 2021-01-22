    namespace MyActiveX
    {
        [Guid("Your-GUID") ,InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IActiveXEvents
        {
            [DispId(1)]
            void OnMouseClick(int index);
        }
    	
    	[Guid("Another-DUIF"),InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        public interface IActiveX
        {       
            //[DispId(1)]
            // Any properties you want here like this
            // string aProperty { get; set; }        
        }
    	
    	[ComVisible(true)]
        [Guid("Yet-Another-GUID"), ClassInterface(ClassInterfaceType.None)]
        [ProgId("MyActiveX")]
        [ComSourceInterfaces(typeof(IActiveXEvents))]
        public partial class MyActiveX : UserControl, IActiveX
        {
    		public delegate void OnMouseClickHandler(int index);
    		
    		public event OnMouseClickHandler OnMouseClick;
    		
    		// Dummy Method to use when firing the event
    		private void MyActiveX_nMouseClick(int index)
            {
    
            }
    		
    		public MyActiveX()
            {
                InitializeComponent();
    			
    			// Bind event
                this.OnMouseClick = new OnMouseClickHandler(this.MyActiveX_MouseClick)
    		}
    		
    		public void FireTheEvent()
    		{
    			int index = -1;
    			this.OnMouseClick(index);
    		}		
    	}
    }
