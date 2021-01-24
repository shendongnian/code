    public partial class frmEvent : Form
    {
      private int SelectedDate;
      public frmEvent(int selectedDate)
      {
        InitializeComponent();
        SelectedDate = selectedDate;
      }
    }
    public partial class frmMain : Form
    {
        private void monthCalendar1_SelectedDate(object sender, DateRangeEventArgs e)
        {
            var selectedDate = (DateTime.Parse(e.Start.ToShortDateString())).Day;
            frmEvent frmE = new frmEvent(selectedDate);
            frmE.Show();
        }
    }
