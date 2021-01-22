    // FooControl.ascx.cs
    namespace WebApplication1
    {
        public enum TypeEnum
        {
            Asynch = 0,
            Synch = 1,
            OneShot = 2
        }
    
        public partial class FooControl : System.Web.UI.UserControl
        {
            public TypeEnum Type { get; set; }
        }
    }
