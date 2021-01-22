    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Value = DateTime.Now.Date.AddHours(DateTime.Now.Hour);
            mPrevDate = dateTimePicker1.Value;
            dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
        }
        private DateTime mPrevDate;
        private bool mBusy;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            if (!mBusy) {
                mBusy = true;
                DateTime dt = dateTimePicker1.Value;
                if ((dt.Minute * 60 + dt.Second) % 300 != 0) {
                    TimeSpan diff = dt - mPrevDate;
                    if (diff.Ticks < 0) dateTimePicker1.Value = mPrevDate.AddMinutes(-5);
                    else dateTimePicker1.Value = mPrevDate.AddMinutes(5);
                }
                mBusy = false;
            }
            mPrevDate = dateTimePicker1.Value;
        }
    }
