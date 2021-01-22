    protected void checkboxlist_SelectedIndexChanged(object sender, EventArgs e)
    {
            CheckBoxList list = (CheckBoxList)sender;
            string[] control = Request.Form.Get("__EVENTTARGET").Split('$');
            int idx = control.Length - 1;
            string sel = list.Items[Int32.Parse(control[idx])].Value;  
     }
