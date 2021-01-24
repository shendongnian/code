    public abstract class MyCbo_Abstract : ComboBox
    {
	
	    // create an event handler property for each event the app has custom code for
	
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private EventHandler evSelectedValueChanged;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EventHandler EvSelectedValueChanged { get => evSelectedValueChanged; set => evSelectedValueChanged = value; }
        public MyCbo_Abstract() : base()
        {
        }
		
		// Create a property that parallels the one that would normally be set in the main body of the program
		public object _DataSource_NoEvents
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                SelectedValueChanged -= EvSelectedValueChanged;
                if (value == null)
                {
                    base.DataSource = null;
                    SelectedValueChanged += EvSelectedValueChanged;
                    return;
                }
                string valueTypeName = value.GetType().Name;
                if (valueTypeName == "Int32")
                {
                    base.DataSource = null;
                    SelectedValueChanged += EvSelectedValueChanged;
                    return;
                }
                //assume StringCollection
                base.DataSource = value;
                SelectedValueChanged += EvSelectedValueChanged;
                return;
            }
        }
    }
    public partial class MyCboFooList : MyCbo_Abstract
    {
        public MyCboFooList() : base()
        {
        }
    }
	
