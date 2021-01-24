    public class BaseClass : UserControl, INotifyPropertyChanged
    {
        public Path ConnIn;
        public Path ConnOut;
        
        private ObjectBase baseObject;
        public ObjectBase BaseObject
        {
            get { return baseObject; }
            set
            {
                baseObject = value;
                if (baseObject != null)
                {
                    baseObject.Title = config.Title;
                    baseObject.GroupID = config.GroupID;
                }
                NotifyPropertyChanged();
            }
        }
        XmlElementConfig config;
        public void BaseClass(XmlElementConfig config)
        {
            this.config = config;
        }
    }
<!---->
    public partial class DerivedClass : CanvasBase
    {
        private Audio_MonitorAction audio_objectAction;
        public DerivedClass(XmlElementConfig config) : base(config)
        {
            InitializeComponent();
            BaseObject = audio_objectAction = new Audio_MonitorAction(createGuid);
        }
    }
