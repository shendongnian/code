        class Target {
            public DurationComboBox Combo { get; private set; }
            public DataView ComboDataView { get; private set; }
            public Form Form { get; private set; }
            public Target() {
                Combo = new DurationComboBox();
                Form = new Form();
                Form.Controls.Add(Combo);
                Form.Show();
                ComboDataView = Combo.DataSource as DataView;
            }
            public IEnumerable<DataRowView> GetComboRows() {
                return (ComboDataView as IEnumerable).Cast<DataRowView>();
            }
        }
