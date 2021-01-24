    public partial class frmEvent : Form
    {
        public int SelectedDate { get; set; }
        public frmEvent()
        {
            InitializeComponent();
        }
    }
    public partial class frmMain : Form
    {
        private void monthCalendar1_SelectedDate(object sender, DateRangeEventArgs e)
        {
            var selectedDate = (DateTime.Parse(e.Start.ToShortDateString())).Day;
            frmEvent frmE = new frmEvent();
            frmE.SelectedDate = selectedDate;
            frmE.Show();
        }
    }
