    namespace WindowsFormsApplication
    {
        public partial class FormMain : Form
        {
            private bool _IsDialog = false;
            private int _InstanceCounter = 1;
            private string _Suffix = String.Empty;
            public FormMain()
            {
                InitializeComponent();
            }
            //Special constructor to see in Caption of the Form
            //that this is a child window
            public FormMain(string suffix)
                : this()
            {
                _Suffix = suffix;
                Text += " " + _Suffix;
            }
            //Reflects the content of the TextBox to the outer world
            public string Result
            {
                get
                {
                    return textBoxMessage.Text;
                }
                set
                {
                    textBoxMessage.AppendText(value + Environment.NewLine);
                    //Fire an event if the content has changed
                    ResultChanged.Raise(this);
                }
            }
            public event EventHandler ResultChanged;
            //Overwrite ShowDialog() to find out if where called by Show() or ShowDialog()
            public new DialogResult ShowDialog()
            {
                _IsDialog = true;
                return base.ShowDialog();
            }
            //Pass event of changed text of the TextBox to the outer world
            private void OnTextChanged(object sender, EventArgs e)
            {
                ResultChanged.Raise(this);
            }
            private void OnButtonResultClick(object sender, EventArgs e)
            {
                //Create a new child form (including new suffix to see that this is a child)
                var childForm = new FormMain(_Suffix + "." + _InstanceCounter++.ToString());
                //Start modal and wait for the result
                if (DialogResult.OK == childForm.ShowDialog())
                {
                    Result = childForm.Result;
                }
            }
            private void OnButtonEventClick(object sender, EventArgs e)
            {
                //Create a new child form (including new suffix to see that this is a child)
                var childForm = new FormMain(_Suffix + "." + _InstanceCounter++.ToString());
                //Listen to events of the child form
                childForm.ResultChanged += OnChildFormResultChanged;
                childForm.FormClosed += OnChildFormFormClosed;
                //Open the form concurrently
                childForm.Show();
            }
            private void OnButtonExitClick(object sender, EventArgs e)
            {
                //When we were not opened with ShowDialog() we have to do
                //the closing on ourself.
                if (!_IsDialog)
                {
                    var button = sender as Button;
                    if (button != null)
                    {
                        DialogResult = button.DialogResult;
                        Close();
                    }
                }
            }
            void OnChildFormResultChanged(object sender, EventArgs e)
            {
                //Write changes from child form into our TextBox
                var childForm = sender as FormMain;
                if (childForm != null)
                {
                    Result = childForm.Result;
                }
            }
            void OnChildFormFormClosed(object sender, FormClosedEventArgs e)
            {
                //Disconnect events from child form
                var childForm = sender as FormMain;
                if (childForm != null)
                {
                    childForm.ResultChanged -= OnChildFormResultChanged;
                    childForm.FormClosed -= OnChildFormFormClosed;
                }
            }
        }
        public static class EventExtensions
        {
            //Simple extension class to wrap thread safe firing of events
            public static void Raise(this EventHandler handler, object sender)
            {
                var temp = handler;
                if (temp != null)
                    temp(sender, EventArgs.Empty);
            }
        }
    }
