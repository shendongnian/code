    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            IntegerClass[] choices = new[] {
                new IntegerClass { Code = 123, Description = "a b c"},
                new IntegerClass { Code = 456, Description = "d e f"},
                new IntegerClass { Code = 789, Description = "g h i"},
            };
            ComboBox cbo = new TwoWayComboBox();
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.DataSource = choices;
            Form form = new Form();
            ClassBindingClass obj = new ClassBindingClass();
            cbo.DataBindings.Add("SelectedItem", obj, "Choice", true, DataSourceUpdateMode.OnPropertyChanged);
            form.DataBindings.Add("Text", obj, "Choice", true, DataSourceUpdateMode.OnPropertyChanged); // show it
            form.Controls.Add(cbo);
            Application.Run(form);
    
    
        }
        
    }
    
    class TwoWayComboBox : ComboBox {
        public new object SelectedItem
        {
            get { return base.SelectedItem; }
            set { base.SelectedItem = value; }
        }
        private static readonly object SelectedItemChangedKey = new object();
        public event EventHandler SelectedItemChanged {
            add { Events.AddHandler(SelectedItemChangedKey, value);}
            remove { Events.RemoveHandler(SelectedItemChangedKey, value);}
        }
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[SelectedItemChangedKey];
            if (handler != null) { handler(this, EventArgs.Empty); }
            base.OnSelectedIndexChanged(e);
        }
    }
