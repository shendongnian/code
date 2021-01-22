    using System.Windows.Forms;
    using System.ComponentModel;
    
    //use like this.ImageList = StaticImageList.Instance.GlobalImageList
    //can use designer on this class but wouldn't want to drop it onto a design surface
    [ToolboxItem(false)]
    public class StaticImageList : Component
    {
        private ImageList globalImageList;
        public ImageList GlobalImageList
        {
            get
            {
                return globalImageList;
            }
            set
            {
                globalImageList = value;
            }
        }
    
        private IContainer components;
     
        private static StaticImageList _instance;
        public static StaticImageList Instance
        {
            get
            {
                if (_instance == null) _instance = new StaticImageList();
                return _instance;
            }
        }
    
        private StaticImageList ()
    	    {
            InitializeComponent();
    	    }
    
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.globalImageList = new System.Windows.Forms.ImageList(this.components);
            // 
            // GlobalImageList
            // 
            this.globalImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.globalImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.globalImageList.TransparentColor = System.Drawing.Color.Transparent;
        }
    }
