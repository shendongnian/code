    public static void SelectItemByValue(this ComboBox cbo, string value)
    {
        for(int i=0; i < cbo.Items.Count; i++)
        {
            var prop = cbo.Items[i].GetType().GetProperty(cbo.ValueMember);
            if (prop!=null && prop.GetValue(cbo.Items[i], null).ToString() == value)
            {
                 cbo.SelectedIndex = i;
                 break;
            }
        } 
    }
