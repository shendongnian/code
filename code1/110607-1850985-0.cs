      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          comboBox1.Items.Add(new Item(1, "one"));
          comboBox1.Items.Add(new Item(2, "two"));
          comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
          Item item = comboBox1.Items[comboBox1.SelectedIndex] as Item;
          MessageBox.Show(item.Value.ToString());
        }
        private class Item {
          public Item(int value, string text) { Value = value; Text = text; }
          public int Value { get; set; }
          public string Text { get; set; }
          public override string ToString() { return Text; }
        }
      }
