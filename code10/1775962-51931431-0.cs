    public class ClickTrafficer {
        private UC target;
        public void HandleClick(object sender, UCClickHandlerEventArgs ea) {
            target.WriteText(ea.TextToWrite);
        }
    }
    public Form1()
    {
        InitializeComponent();
        var trafficer = new ClickTrafficer();
        var screen1 = new Screens.UC1();
        screen1.Click += trafficer.HandleClick;
        panel1.Controls.Add(screen1);
    }
