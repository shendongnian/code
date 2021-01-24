    public partial class Form1 : Form, IButtonControl
    {
        public Form1()
        {
            InitializeComponent();
            CancelButton = this;
        }
        DialogResult IButtonControl.DialogResult
        {
            get {return  DialogResult.OK;}
            set {}
        }
        void IButtonControl.NotifyDefault(bool value) { }
        void IButtonControl.PerformClick()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
