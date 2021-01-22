        class TestCombo : DurationComboBox {
            public void SimulateKeyUp(Keys keys) { base.OnKeyUp(new KeyEventArgs(keys)); }
            public DataView DataView { get { return DataSource as DataView; } }
            public IEnumerable<DataRowView> Rows() { return (DataView as IEnumerable).Cast<DataRowView>(); }
            public IEnumerable<int> Minutes() { return Rows().Select(row => (int)row["Minutes"]); }
        }
        class Target {
            public TestCombo Combo { get; private set; }
            public Form Form { get; private set; }
            public Target() {
                Combo = new TestCombo();
                Form = new Form();
                Form.Controls.Add(Combo);
                Form.Show();
            }
        }
