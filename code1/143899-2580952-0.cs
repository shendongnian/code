      public partial class Form1 : Form {
        public Form1() {
          InitializeComponent();
          dateTimePicker1.KeyDown += squelchBeep;
        }
        private void squelchBeep(object sender, KeyEventArgs e) {
          if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape) e.SuppressKeyPress = true;
        }
      }
