     private int GetGroupBoxValue(GroupBox gb)
        {
            int nReturn = 0;
            foreach (Control ctl in gb.Controls)
            {
                if (ctl.GetType() == typeof(RadioButton))
                {
                    if (((RadioButton)ctl).Checked)
                    {
                        nReturn = Convert.ToInt32(ctl.Tag);
                        break;
                    }
                }
            }
            return nReturn;
        }
