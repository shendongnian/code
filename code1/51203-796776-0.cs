    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private bool _keyHeld;
            public Form1()
            {
                InitializeComponent();
                this.KeyUp += new KeyEventHandler(Form1_KeyUp);
                this.KeyDown += new KeyEventHandler(Form1_KeyDown);
                this._keyHeld = false;
            }
            void Form1_KeyUp(object sender, KeyEventArgs e)
            {
                this._keyHeld = false;
            }
            void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (!this._keyHeld)
                {
                    this._keyHeld = true;
                    if (this.BackColor == Control.DefaultBackColor)
                    {
                        this.BackColor = Color.Red;
                    }
                    else
                    {
                        this.BackColor = Control.DefaultBackColor;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }   
    }
