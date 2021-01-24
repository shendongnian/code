     if (inputBox.ShowDialog() == DialogResult.OK)
     {
        input1 = (panel.GetControlFromPosition(1, 0) as TextBox).Text;
        input2 = (panel.GetControlFromPosition(1, 1) as TextBox).Text;
        return DialogResult.OK;
     }
     
     return DialogResult.Cancel;
