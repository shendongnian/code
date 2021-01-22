      public ToolTip() : base() {
      }
      public ToolTip(System.ComponentModel.IContainer components) : base(components) {
      }
      public new void SetToolTip(System.Windows.Forms.Control ctl, string caption) {
         ctl.MouseEnter -= new System.EventHandler(toolTip_MouseEnter);
         base.SetToolTip(ctl, caption);
         if(caption != string.Empty)
         ctl.MouseEnter += new System.EventHandler(toolTip_MouseEnter);
      }
      private void toolTip_MouseEnter(object sender, EventArgs e) {
         this.Active = false;
         this.Active = true;
      }
}
