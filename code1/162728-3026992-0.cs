    public partial class Form1 : Form
    {
       private DateTime _initialDateTime = DateTime.Now;
       public Form1()
       {
         InitializeComponent();
         // remember the default MAX date
         _initialDateTime = monthCalendar1.MaxDate;
         // set max date to NOW to force current month to right side
         monthCalendar1.MaxDate = DateTime.Now;
         // enable a timer to restore initial default date to enable scrolling into the future
         timer1.Start();
       }
       private void timer1_Tick(object sender, EventArgs e)
       {
         Timer timer = sender as Timer;
         if (timer != null)
         {
            // enable scrolling to the future
            monthCalendar1.MaxDate = _initialDateTime;
            // stop the timer...
            timer.Stop();
         }
       }
    }
