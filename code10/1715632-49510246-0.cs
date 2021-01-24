     List<int> filter = groupBox1.Controls.OfType<CheckBox>()
                                 .Where(cb => cb.Checked)
                                 .select(cbx => parseTag(cbx.Tag.toString()))
                                 .ToList();
    private int parseTag(string tag) 
    {   
      int num;   
      if (!Int32.TryParse(tag, out num)) 
      {
        num = int.MaxValue; // or int.MinValue - however it should show up in sort   
      }
      return num; 
    }
