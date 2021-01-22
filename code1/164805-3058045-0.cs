    public void MyComboBox_SelectedIndexChanged(object sender, EventArgs args)
    {
       ComboBox box = sender as ComboBox;
       if (box != null) return;
       switch(box.Text)
       {
          case "Value1":
          case "Value2":
          case "Value3":
             myTextBox.Enabled = false;
             break;
          default:
             myTextBox.Enabled = true;
       }
    }
