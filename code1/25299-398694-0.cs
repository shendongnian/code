      public partial class Form1 : Form {
        MyListBox mList;
        public Form1() {
          InitializeComponent();
        }
    
        protected override void OnLoad(EventArgs e) {
          mList = new MyListBox(this);
          mList.Location = new Point(5, 10);
          mList.Size = new Size(50, this.ClientSize.Height + 50);
          for (int ix = 0; ix < 100; ++ix) mList.Items.Add(ix);
          mList.SelectedIndexChanged += new EventHandler(mList_SelectedIndexChanged);
        }
    
        void mList_SelectedIndexChanged(object sender, EventArgs e) {
          MessageBox.Show(mList.SelectedIndex.ToString());
        }
    
        protected override void Dispose(bool disposing) {
          // Moved from Designer.cs file
          if (disposing) mList.Dispose();
          if (disposing && (components != null)) {
            components.Dispose();
          }
          base.Dispose(disposing);
        }
    
      }
