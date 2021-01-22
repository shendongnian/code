    class FormB : Form{
        void Foo(){
            SetNativeEnabled(false); // defined above
            FormD f = new FormD();
            f.Closed += (s, e)=>{
                switch(f.DialogResult){
                case DialogResult.OK:
                    // Do OK logic
                    break;
                case DialogResult.Cancel:
                    // Do Cancel logic
                    break;
                }
                SetNativeEnabled(true);
            };
            f.Show(this);
            // function Foo returns now, as soon as FormD is shown
        }
    }
    class FormD : Form{
        public FormD(){
            Button btnOK       = new Button();
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Text         = "OK";
            btnOK.Click       += (s, e)=>Close();
            btnOK.Parent       = this;
            Button btnCancel       = new Button();
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Text         = "Cancel";
            btnCancel.Click       += (s, e)=>Close();
            btnCancel.Parent       = this;
            AcceptButton = btnOK;
            CancelButton = btnCancel;
        }
    }
