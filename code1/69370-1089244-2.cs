    private void frmMain_Load(object sender, EventArgs e)
    {
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
    private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.MaxLength = 15;
                // Change all text entered to be lowercase.
                textBox1.CharacterCasing = CharacterCasing.Lower;
                if (checkedListBox1.Items.Contains(textBox1.Text) == false)
                {
                    checkedListBox1.Items.Add(textBox1.Text, CheckState.Checked);
                    textBox1.Text = "";
                    MessageBox.Show("Added! Click Move to see List Box");
                }
                else
                {
                    MessageBox.Show("Already There!");
                    textBox1.Text = "";
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
