    public partial class MainForm : Form
    {
        // Your class instance.
        private SomeClass InstanceOfSomeClass = null;
        public MainForm()
        {
            InitializeComponent();
            // Initialize the RaBucket1Type property with Yellow.
            InstanceOfSomeClass = new SomeClass(RaTypes.Yellow);
            // Populating the ComboBox
            comboBox1.DataSource = Enum.GetValues(typeof(RaTypes));
        }
        // At selected index changed event
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected value.
            var selected = comboBox1.SelectedValue;
            // Change the `RaBucket1Type` value of the class instance according to the user choice.
            InstanceOfSomeClass.RaBucket1Type = (RaTypes)selected;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            // At form load time, set the `SelectedItem` of the `ComboBox` to the value of `RaBucket1Type` of your class instance.
            // Since we initialized it to `Yellow`, the `ComboBox` will show `Yellow` as the selected item at load time.
            if (InstanceOfSomeClass != null)
            {
                comboBox1.SelectedItem = InstanceOfSomeClass.RaBucket1Type;
            }
        }
    }
    public enum RaTypes
    {
        Red,
        Yellow
    }
    public class SomeClass
    {
        public RaTypes RaBucket1Type { get; set; }
        public SomeClass(RaTypes raTypes) { RaBucket1Type = raTypes; }
    }
