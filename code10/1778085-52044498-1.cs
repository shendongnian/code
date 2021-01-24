    using System;
    using System.Windows.Forms;
    namespace QuestionTesting
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
            public void CloseMe()
            {
                BeginInvoke((Action)(() => { Close(); }));
            }
        }
    }
