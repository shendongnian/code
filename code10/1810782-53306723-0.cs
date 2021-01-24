    private void tbValues_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter && num < 5 && !(string.IsNullorEmpty(tbValues.text)))
        {
             values[num] = int.Parse(tbValues.Text);
             listValues.Items.Add(values[num].ToString());
             num ++;
        }
        else
             ...
        tbValues.Clear();
    }
  
