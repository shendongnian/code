        public partial class ProgressBarUdpate : Form
        {
            public ProgressBarUdpate()
            {
                InitializeComponent();
            }
            private void btn_Submit_Click(object sender, EventArgs e)
            {
                UpdateDataProgress updt = new UpdateDataProgress();
                updt.ExecutionDone += updt_ExecutionDone;
                updt.ExecuteFucntion();
            }
            void updt_ExecutionDone(int value)
            {
                //Update your progress bar here as per value
            }
        }
