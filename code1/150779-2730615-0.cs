    using System;
    using System.Windows.Forms;
    
    class MyLabel : Label {
      private TextBox mEditor;
      protected override void OnDoubleClick(EventArgs e) {
        if (mEditor == null) {
          mEditor = new TextBox();
          mEditor.Location = this.Location;
          mEditor.Width = this.Width;
          mEditor.Font = this.Font;
          mEditor.Text = this.Text;
          mEditor.SelectionLength = this.Text.Length;
          mEditor.Leave += new EventHandler(mEditor_Leave);
          this.Parent.Controls.Add(mEditor);
          this.Parent.Controls.SetChildIndex(mEditor, 0);
          mEditor.Focus();
        }
        base.OnDoubleClick(e);
      }
      void mEditor_Leave(object sender, EventArgs e) {
        this.Text = mEditor.Text;
        mEditor.Dispose();
        mEditor = null;
      }
      protected override void Dispose(bool disposing) {
        if (disposing && mEditor != null) mEditor.Dispose();
        base.Dispose(disposing);
      }
    }
