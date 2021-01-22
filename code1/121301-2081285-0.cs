      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          listBox1.SelectionMode = SelectionMode.MultiSimple;
          listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
        }
    
        void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
          for (int ix = listBox1.SelectedIndices.Count - 1; ix >= 0; --ix) {
            int index = listBox1.SelectedIndices[ix];
            if (index % 2 != 0) listBox1.SelectedIndices.Remove(index);
          }
        }
      }
