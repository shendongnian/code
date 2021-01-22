    public class GenericElement<T> {
        public GenericElement(string text) {
            this.Text = text;
        }
        public GenericElement(string text, T tag) : this(text) {
            this.Tag = tag;
        }
        public T Tag {
            get; set;
        }
        public string Text {
            get; set;
        }
        public override string ToString() {
            return Text;
        }
    }
    // Combo-Box example
    public class MyForm : Form {
        private void DoLoad(object sender, EventArgs e) {
            comboNum.Items.Add(new GenericElement<int>("One", 1);
            comboNum.Items.Add(new GenericElement<int>("Two", 2);
            comboNum.Items.Add(new GenericElement<int>("Three", 3);
        }
        public int SelectedNumber {
            get {
                GenericElement<int> el =
                    comboNum.SelectedItem as GenericElement<int>;
                return el == null ? 0 : el.Tag;
            }
        }
    }
