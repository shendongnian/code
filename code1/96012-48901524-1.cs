    public static void setEnabled (ControlCollection cntrList ,bool enabled,List<Type> typeList = null)
    {
        foreach (Control cntr in cntrList)
        {
            if (cntr.Controls.Count == 0)
                if (typeList != null)
                {
                    if (typeList.Contains(cntr.GetType()))
                        cntr.Enabled = enabled;
                }
                 else
                    cntr.Enabled = enabled;
            else
                    setEnabled(cntr.Controls, enabled, typeList);
        }
    }
    public void loadFormEvents()
    {
        List<Type> list = new List<Type> ();
        list.Add(typeof(TextBox));
        setEnabled(frm.Controls ,false,list);
    }
