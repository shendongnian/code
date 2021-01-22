    public class MyCheckBoxOverride:CheckBox
        {
            protected override void OnKeyDown(KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Oemplus)
                {
                    this.Checked = true;
                }
                else if(e.KeyCode == Keys.OemMinus)
                {
                    this.Checked = false;
                }
                base.OnKeyDown(e);
            }
    
    
        }
