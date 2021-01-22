    public static class EVENTS
    {
        public const string UPDATE_TICKED = "event://Form1/Ticked";
    }
    public partial class Form1 : Form
    {
        [Publishes(EVENTS.UPDATE_TICKED)]
        public event EventHandler Ticked; 
        
        void the_timer_Tick(object sender, EventArgs e)
        {
            // I would like code in here to update all instances of SecondaryForm
            // that happen to be open now.
            MessageBox.Show("Timer ticked");
        }
    }
    
    public partial class SecondaryForm : Form
    {
        [SubscribesTo(EVENTS.UPDATE_TICKED)]
        private void Form1_Ticked(object sender, EventHandler e)
        {
            // code to handle tick in SecondaryForm
        }
    }
