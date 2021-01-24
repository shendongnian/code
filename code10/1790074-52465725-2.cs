    public class AnotherClass
    {
        public AnotherClass(WebForm1 wf)
        {
    
            Button btnConfirm = new Button();
    
            btnConfirm.Text = "Confirm";
            btnConfirm.CommandName = "Variable1,Variable2,Variable3";
            wf.Form.Controls.Add(btnConfirm);
    
            btnConfirm.Click += new EventHandler(wf.btnConfirmBook_Click);
    
        }
    }
