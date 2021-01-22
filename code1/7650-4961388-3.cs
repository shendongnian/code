namespace NumberedTextBoxLib {
  partial class NumberedTextBox {
    /// Required designer variable.
    private System.ComponentModel.IContainer components = null;
    /// Clean up any resources being used.
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    private void InitializeComponent() {
      this.editBox = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // editBox
      // 
      this.editBox.AcceptsTab = true;
      this.editBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.editBox.Location = new System.Drawing.Point(27, 3);
      this.editBox.Name = "editBox";
      this.editBox.Size = new System.Drawing.Size(122, 117);
      this.editBox.TabIndex = 0;
      this.editBox.Text = "";
      this.editBox.WordWrap = false;
      // 
      // NumberedTextBox
      // 
      this.Controls.Add(this.editBox);
      this.Name = "NumberedTextBox";
      this.Size = new System.Drawing.Size(152, 123);
      this.ResumeLayout(false);
    }
    private System.Windows.Forms.RichTextBox editBox;
  }
}
