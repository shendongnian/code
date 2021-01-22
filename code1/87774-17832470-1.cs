    Judge judge = new Judge
                    {
                        judgename = comboName.Text,
                        judgement = checkjudgement.Checked,
                        sequence = txtsequence.Text,
                        author = checkauthor.Checked,
                        id = Convert.ToInt32(comboName.SelectedValue)
                    };
    
                ListViewItem lvi = new ListViewItem(judge.judgename);
                lvi.SubItems.Add(judge.judgement ? "Yes" : "No");
                lvi.SubItems.Add(string.IsNullOrEmpty(judge.sequence) ? "" : txtsequence.Text);
                lvi.SubItems.Add(judge.author ? "Yes" : "No");
                lvi.SubItems.Add((judge.id).ToString());
                if (listView1.Items.Count != 0)
                {
                    ListViewItem item = listView1.FindItemWithText(comboName.SelectedValue.ToString(), true, 0);
                    if (item != null)
                    {
                        // it exists
                    }
                    else
                    {
                        // doesn't exist
                    }
                    
                }
