    using System.Windows.Forms;
    
    var label = new Label();
    label.AutoSize = false;
    label.AutoEllipsis = true;
    label.Text = "This text will be too long to display all together.";
    
    var labelToolTip = new ToolTip();
    labelToolTip.SetToolTip(label, label.Text);
