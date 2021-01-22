      if (!string.IsNullOrEmpty(Properties.Settings.Default.CheckedItems))
      {
        string[] checkedIndicies = Properties.Settings.Default.CheckedItems.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i1 = 0; i1 < checkedIndicies.Length; i1++)
        {
          int idx;
          if ((int.TryParse(checkedIndicies[i1], out idx)) && (checkedListBox1.Items.Count >= (idx+1)))
          {
            checkedListBox1.SetItemChecked(idx, true);
          }
        }
      }
    }
    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      string idx = string.Empty;
      for (int i1 = 0; i1 < checkedListBox1.CheckedIndices.Count; i1++)
        idx += (string.IsNullOrEmpty(idx) ? string.Empty : ",") + Convert.ToString(checkedListBox1.CheckedIndices[i1]);
      Properties.Settings.Default.CheckedItems = idx;
      Properties.Settings.Default.Save();
    }
