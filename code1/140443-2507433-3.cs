    public class CBaseForm : Form
    { public CBaseForm() { this.Text = "Main App"; } }
    
    public class MyWarningForm : CBaseForm
    { public MyWarningForm() { Label lbl = new Label(); lbl.Text = "Warning Form"; this.Controls.Add(lbl); } }
    
    public class MyNotificationForm : CBaseForm
    { public MyNotificationForm() { Label lbl = new Label(); lbl.Text = "Notification Form"; this.Controls.Add(lbl); } }
    
    public class MyMainForm : CBaseForm
    { public MyMainForm() { Label lbl = new Label(); lbl.Text = "Controller Form"; this.Controls.Add(lbl); } }
    
