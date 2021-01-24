    public partial class FormComboBoxBinding : Form
    {
        DataTable dt;
        public FormComboBoxBinding()
        {
            InitializeComponent();
            comboBox1.LazyBind = LoadBind;
        }
        private void LoadBind()
        {
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("messages", typeof(string));
                dt.Columns.Add("c_id", typeof(int));
                for (int i = 0; i < 10; i++)
                {
                    dt.Rows.Add("message " + i.ToString(), i);
                }
                comboBox1.DataSource = dt.DefaultView;
                comboBox1.DisplayMember = "messages";
                comboBox1.ValueMember = "c_id";
            }
        }
    }
    public class ComboBoxEx : ComboBox
    {
        public Action LazyBind { get; set; }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
        protected override void OnDropDown(EventArgs e)
        {
            if (LazyBind != null) LazyBind();
            base.OnDropDown(e);
        }
    }
