partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ToopTip toolTip1;
    // ...
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.label1 = new System.Windows.Forms.Label();
        this.toolTip1 = new System.Windows.Forms.Tooltip(this.components);
        // ...
        this.toolTip1.SetToolTip(this.label1, "abc");
        // ...
    }
}
