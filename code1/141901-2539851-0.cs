    public partial class MainForm : Form {
        // We assume we have let's say three CheckBoxes named chkFirst, chkSecond and chkThird
        public bool IsFirstChecked { get { return chkFirst.Checked; } }
        public bool IsSecondChecked { get { return chkSecond.Checked; } }
        public bool IsThirdChecked { get { return chkThird.Checked; } }
        // Calling this form from where these checked states will be processed...
        // Let's suppose we have to click a button to launch the process, for instance...
        private void btnLaunchProcess(object sender, EventArgs e) {
            ProcessForm f = new ProcessForm();
            f.Parent = this;
            if (DialogResult.OK == f.ShowDialog()) {
                // Process accordingly if desired, otherwise let it blank...
            }
        }       
    }
    public partial class ProcessForm : Form {
        // Accessing the checked state of CheckBoxes
        private void Process() {
            if ((this.Parent as MainForm).FirstChecked)
                // Process according to first CheckBox.Checked state.
            else if ((this.Parent as MainForm).SecondChecked)
                // Process according to second CheckBox.Checked state.
            else if ((this.Parent as MainForm).ThirdChecked)
                // Process according to third CheckBox.Checked state.
        }
    }
