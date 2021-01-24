    public class AnotherClass
    {
        public AnotherClass(Default def)
        {
    
            Button btnConfirm = new Button();
    
            btnConfirm.Text = "Confirm";
            btnConfirm.CommandName = "Variable1,Variable2,Variable3";
            def.Form.Controls.Add(btnConfirm);
    
            btnConfirm.Click += new EventHandler(def.btnConfirmBook_Click);
    
        }
    }
