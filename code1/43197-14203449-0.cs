    class RadioButtonBinding : ILookup<System.Enum, System.Windows.Forms.RadioButton>
    {
        private Type enumType;
        private List<System.Windows.Forms.RadioButton> radioButtons;
        private System.Windows.Forms.BindingSource bindingSource;
        private string propertyName;
        public RadioButtonBinding(Type myEnum, System.Windows.Forms.BindingSource bs, string propertyName)
        {
            this.enumType = myEnum;
            this.radioButtons = new List<System.Windows.Forms.RadioButton>();
            foreach (string name in System.Enum.GetNames(this.enumType))
            {
                System.Windows.Forms.RadioButton rb = new System.Windows.Forms.RadioButton();
                rb.Text = name;
                this.radioButtons.Add(rb);
                rb.CheckedChanged += new EventHandler(rb_CheckedChanged);
            }
            this.bindingSource = bs;
            this.propertyName = propertyName;
            this.bindingSource.DataSourceChanged += new EventHandler(bindingSource_DataSourceChanged);
        }
        void bindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            object obj = this.bindingSource.Current;
            System.Enum item = obj.GetType().GetProperty(propertyName).GetValue(obj, new object[] { }) as System.Enum;
            foreach (System.Enum value in System.Enum.GetValues(this.enumType))
            {
                if (this.Contains(value))
                {
                    System.Windows.Forms.RadioButton rb = this[value].First();
                    if (value.Equals(item))
                    {
                        rb.Checked = true;
                    }
                    else
                    {
                        rb.Checked = false;
                    }
                }
            }
        }
        void rb_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton rb = sender as System.Windows.Forms.RadioButton;
            System.Enum val = null;
            try
            {
                val = System.Enum.Parse(this.enumType, rb.Text) as System.Enum;
            }
            catch(Exception ex)
            {
                // cannot occurred if code is safe
                System.Windows.Forms.MessageBox.Show("No enum value for this radio button : " + ex.ToString());
            }
            object obj = this.bindingSource.Current;
            obj.GetType().GetProperty(propertyName).SetValue(obj, val, new object[] { });
            this.bindingSource.CurrencyManager.Refresh();
        }
        public int Count
        {
            get
            {
                return System.Enum.GetNames(this.enumType).Count();
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.radioButtons.GetEnumerator();
        }
        public bool Contains(Enum key)
        {
            return System.Enum.GetNames(this.enumType).Contains(key.ToString());
        }
        public IEnumerable<System.Windows.Forms.RadioButton> this[Enum key]
        {
            get
            {
                return this.radioButtons.FindAll(a => { return a.Text == key.ToString(); });
            }
        }
        IEnumerator<IGrouping<Enum, System.Windows.Forms.RadioButton>> IEnumerable<IGrouping<Enum, System.Windows.Forms.RadioButton>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void AddControlsIntoGroupBox(System.Windows.Forms.GroupBox gb)
        {
            System.Windows.Forms.FlowLayoutPanel panel = new System.Windows.Forms.FlowLayoutPanel();
            panel.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            foreach (System.Windows.Forms.RadioButton rb in this.radioButtons)
            {
                panel.Controls.Add(rb);
            }
            gb.Controls.Add(panel);
        }
    }
