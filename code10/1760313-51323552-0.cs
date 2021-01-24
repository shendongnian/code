    /// <summary>
    /// Check all check boxes and vice versa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        //Declare your checkedListBox2 count
        iCount = checkedListBox2.Items.Count;
        if (sender != null)
        {
            for (int i = 1; i <= iCount; i++)
            {
                CheckBox ck = null;
                Control[] chkTest = this.Controls.Find("chkDrive" + i, true);
                if (chkTest.Length > 0)
                {
                    if (chkSelectAll.Checked)
                    {
                        for (int j = 0; j < chkTest.Length; j++)
                        {
                            ck = (CheckBox)chkTest[j];
                            ck.Checked = true;
                        }
                    }
                    else
                    {
						ck = (CheckBox)chkTest[0];
						if (ck.CheckState == CheckState.Unchecked)
						{
							ck.Checked = false;
						}
                    }
                }
            }
        }            
    }
 
