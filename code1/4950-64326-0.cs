    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace SampleApplication
    {
        public partial class CustomUserControl : UserControl
        {
            public CustomUserControl()
            {
                InitializeComponent();
            }
    
            /// <summary>
            /// We're hiding AutoSizeMode in UserControl here.
            /// </summary>
            public new enum AutoSizeMode { None, KeepInControl }
            public enum VerticalControlAlign { Center, Top, Bottom }
    
            /// <summary>
            /// Note that you cannot have a property  
            /// called VerticalControlAlign if it is   
            /// already defined in the scope.
            /// </summary>
            [DisplayName("VerticalControlAlign")]
            [Category("stackoverflow.com")]
            [Description("Sets the vertical control align")]
            public VerticalControlAlign VerticalControlAlign_Ugly
            {
                get { return m_align; }
                set { m_align = value; }
            }
            private VerticalControlAlign m_align;        
            
            /// <summary>
            /// Note that you cannot have a property  
            /// called AutoSizeMode if it is   
            /// already defined in the scope.
            /// </summary>
            [DisplayName("AutoSizeMode")]
            [Category("stackoverflow.com")]
            [Description("Sets the auto size mode")]
            public AutoSizeMode AutoSizeMode_Ugly
            {
                get { return m_autoSize; }
                set { m_autoSize = value; }
            }
            private AutoSizeMode m_autoSize;	
        }
    }
