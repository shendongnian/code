    var checkedMonthNumbers = new List<int>();
    
    foreach (CheckBox chk in this.Controls.OfType<CheckBox>())
           {
             if (chk.Checked)
                    {
                        checkedMonthNumbers.Add(GetMonthNumberFromCheckBox(chk));
                    }
           }
    
    MessageBox.Show("Required timespan is " + GetLatestSpan(checkedMonthNumbers, StartDate));
