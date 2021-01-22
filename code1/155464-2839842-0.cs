    public class Controller : ApplicationContext {
        public Controller() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mInstance = this;
        }
        public Controller Instance { get { return mInstance; } }
        public void Start() {
            Application.Run(this);
        }
        public void Exit() {
            this.ExitThread();
        }
        public void CreateView(Form frm) {
            Views.Add(frm);
            frm.FormClosed += FormClosed;
            frm.Show();
        }
        private void FormClosed(object sender, FormClosedEventArgs e) {
            Views.Remove(sender as Form);
            // NOTE: terminate program when last view closed
            if (Views.Count == 0) Exit();
        }
        private List<Form> Views = new List<Form>();
        private Controller mInstance;
    }
