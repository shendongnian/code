    public class Form2 : Form
    {
        Mutex m;
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            m = new Mutex(true, "Form2");
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            m.ReleaseMutex();
        }
    }
    public class Form3 : Form
    {
        bool form2IsOpen;
        public Form3()
        {
            try
            {
                Mutex.OpenExisting("Form2");
                form2IsOpen = true;
            }
            catch (WaitHandleCannotBeOpenedException ex)
            {
                form2IsOpen = false;
            }
        }
    }
