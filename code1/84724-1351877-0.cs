    public partial class Form1 : System.Windows.Forms.Form {
    
        SyncList<object> _List; 
        public Form1() {
            InitializeComponent();
            _List = new SyncList<object>(this);
        }
    }
    
    public class SyncList<T> : System.ComponentModel.BindingList<T> {
    
        private System.ComponentModel.ISynchronizeInvoke _SyncObject;
        private System.Action<System.ComponentModel.ListChangedEventArgs> _FireEventAction;
    
        public SyncList() : this(null) {
        }
    
        public SyncList(System.ComponentModel.ISynchronizeInvoke syncObject) {
    
            _SyncObject = syncObject;
            _FireEventAction = FireEvent;
        }
    
        protected override void OnListChanged(System.ComponentModel.ListChangedEventArgs args) {
            if(_SyncObject == null) {
                FireEvent(args);
            }
            else {
                _SyncObject.Invoke(_FireEventAction, new object[] {args});
            }
        }
    
        private void FireEvent(System.ComponentModel.ListChangedEventArgs args) {
            base.OnListChanged(args);
        }
    }
