    public partial class MyForm : Form
    {
      Timer activityTimer = new Timer();
      TimeSpan activityThreshold = TimeSpan.FromSeconds(2);
      bool cursorHidden = false;
    
      public Form1()
      {
        InitializeComponent();
    
        activityTimer.Tick += activityWorker_Tick;
        activityTimer.Interval = 100;
        activityTimer.Enabled = true;
      }
    
      void activityWorker_Tick(object sender, EventArgs e)
      {
        bool shouldHide = User32Interop.GetLastInput() > activityThreshold;
        if (cursorHidden != shouldHide)
        {
          if (shouldHide)
            Cursor.Hide();
          else
            Cursor.Show();
    
          cursorHidden = shouldHide;
        }
      }
    }
