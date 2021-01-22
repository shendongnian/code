    foreach(var box in _comboBoxList)
    {
          Tex.Write(Tex.NewLine);
          if (box.Text != "Pick One")
          {
              Tex.WriteLine("Day: " + box.Text);
          }
          else
          {
              Tex.WriteLine("Day: N/A");
          }
    }
