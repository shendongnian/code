    public partial class SomeChip : UserControl
    {
        public event PinPanelClick ClickedPinPanel;
        public delegate void PinPanelClick(int index, bool input);
        private PinPanel[] inputPins;
        private PinPanel[] outputPins;
        private int _NumberInputPins = 2;
        public int NumberInputPins
        {
            get {
                return _NumberInputPins;
            }
            set
            {
                if (value > 0 && value != _NumberInputPins)
                {
                    _NumberInputPins = value;
                    CreatePinPanels();
                    this.Refresh();
                }
            }
        }
        private int _NumberOutputPins = 1;
        public int NumberOutputPins
        {
            get
            {
                return _NumberOutputPins;
            }
            set
            {
                if (value > 0 && value != _NumberOutputPins)
                {
                    _NumberOutputPins = value;
                    CreatePinPanels();
                    this.Refresh();
                }
            }
        }
        public SomeChip()
        {
            InitializeComponent();
        }
        private void SomeChip_Load(object sender, EventArgs e)
        {
            CreatePinPanels();
            RepositionPins();
        }
        private void SomeChip_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void SomeChip_Paint(object sender, PaintEventArgs e)
        {
            int PinHeight;
            // draw the input pin runs
            if (inputPins != null)
            {
                PinHeight = (int)((double)this.Height / (double)_NumberInputPins);
                for (int i = 0; i < NumberInputPins; i++)
                {
                    int Y = (i * PinHeight) + (PinHeight / 2);
                    e.Graphics.DrawLine(Pens.Black, 0, Y, this.Width / 4, Y);
                }
            }
            // draw the output pin runs
            if (outputPins != null)
            {
                PinHeight = (int)((double)this.Height / (double)_NumberOutputPins);
                for (int i = 0; i < NumberOutputPins; i++)
                {
                    int Y = (i * PinHeight) + (PinHeight / 2);
                    e.Graphics.DrawLine(Pens.Black, this.Width - this.Width / 4, Y, this.Width, Y);
                }
            }
            //draw the chip itself (takes up 50% of the width of the UserControl)
            Rectangle rc = new Rectangle(new Point(this.Width / 4, 0), new Size(this.Width / 2, this.Height - 1));
            using (SolidBrush sb = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(sb, rc);
            }
            e.Graphics.DrawRectangle(Pens.Black, rc);
            RepositionPins();
        }
        private void CreatePinPanels()
        {
            if (inputPins != null)
            {
                for (int i = 0; i < inputPins.Length; i++)
                {
                    if (inputPins[i] != null && !inputPins[i].IsDisposed)
                    {
                        inputPins[i].Dispose();
                    }
                }
            }
            inputPins = new PinPanel[_NumberInputPins];
            for (int i = 0; i < inputPins.Length; i++)
            {
                inputPins[i] = new PinPanel();
                inputPins[i].Click += OnClickPinPanel;
                this.Controls.Add(inputPins[i]);
            }
            if (outputPins != null)
            {
                for (int i = 0; i < outputPins.Length; i++)
                {
                    if (outputPins[i] != null && !outputPins[i].IsDisposed)
                    {
                        outputPins[i].Dispose();
                    }
                }
            }
            outputPins = new PinPanel[_NumberOutputPins];
            for (int i = 0; i < outputPins.Length; i++)
            {
                outputPins[i] = new PinPanel();
                outputPins[i].Click += OnClickPinPanel;
                this.Controls.Add(outputPins[i]);
            }
        }
        private void OnClickPinPanel(object sender, EventArgs e)
        {
            PinPanel p = (PinPanel)sender;
            if (inputPins.Contains(p))
            {
                ClickedPinPanel?.Invoke(Array.IndexOf(inputPins, p), true);
            }
            else if (outputPins.Contains(p))
            {
                ClickedPinPanel?.Invoke(Array.IndexOf(inputPins, p), false);
            }
        }
        private void RepositionPins()
        {
            int PinRowHeight, PinHeight;
            if (inputPins != null)
            {
                PinRowHeight = (int)((double)this.Height / (double)_NumberInputPins);
                PinHeight = (int)Math.Min((double)(PinRowHeight / 2), (double)this.Height * 0.05);
                for (int i = 0; i < inputPins.Length; i++)
                {
                    if (inputPins[i] != null && !inputPins[i].IsDisposed)
                    {
                        inputPins[i].SetBounds(0, (int)((i * PinRowHeight) + (PinRowHeight /2 ) - (PinHeight / 2)), PinHeight, PinHeight);
                    }
                }
            }
            if (outputPins != null)
            {
                PinRowHeight = (int)((double)this.Height / (double)_NumberOutputPins);
                PinHeight = (int)Math.Min((double)(PinRowHeight / 2), (double)this.Height * 0.05);
                for (int i = 0; i < outputPins.Length; i++)
                {
                    if (outputPins[i] != null && !outputPins[i].IsDisposed)
                    {
                        outputPins[i].SetBounds(this.Width - PinHeight, (int)((i * PinRowHeight) + (PinRowHeight / 2) - (PinHeight / 2)), PinHeight, PinHeight);
                    }
                }
            }
        }
    }
