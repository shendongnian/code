    public class CustomForm : Form
    {
        public static List<CustomForm> AllForms = new List<CustomForm>();
        private static int CurrentFormIndex = 0;
        private static Timer SliderTimer = new Timer() { Interval = 5000 }; // { Interval = 5 * 60000 };
        public static void Start(params CustomForm[] forms)
        {
            AllForms.AddRange(forms);
            forms[0].Show();
            forms[0].WindowState = FormWindowState.Maximized;
            AllForms[0].OnStart(AllForms[0]);
            SliderTimer.Tick += SliderTimer_Tick;
            SliderTimer.Start();
        }
        private static void SliderTimer_Tick(object sender, EventArgs e)
        {
            SliderTimer.Stop();
            // Minimizing current form
            AllForms[CurrentFormIndex].OnStop(AllForms[CurrentFormIndex]);
            AllForms[CurrentFormIndex].WindowState = FormWindowState.Minimized;
            // Maximizing next form
            int NextFormIndex = (CurrentFormIndex + 1) % AllForms.Count;
            if (!AllForms[NextFormIndex].Visible)
                AllForms[NextFormIndex].Show();
            AllForms[NextFormIndex].WindowState = FormWindowState.Maximized;
            AllForms[NextFormIndex].OnStart(AllForms[NextFormIndex]);
            CurrentFormIndex = NextFormIndex;
            SliderTimer.Start();
        }
        // Application will exits when one of forms being closed
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }
        // For overriding in forms to Start something such as playing or etc
        protected virtual void OnStart(CustomForm Sender)
        {
        }
        // For overriding in forms to Stop something such as playing or etc
        protected virtual void OnStop(CustomForm Sender)
        {
        }
    }
