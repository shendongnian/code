        public class YourForm : Form
        {
            public YourForm()
            {
                MySharedData.Instance.DataChanged += Instance_DataChanged;
            }
            private void Instance_DataChanged(object sender, EventArgs e)
            {
                // TODO: redraw your form
            }
        }
