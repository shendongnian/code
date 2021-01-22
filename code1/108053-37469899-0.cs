      private void ShowSelectedRadioButton()
        {
            List<RadioButton> buttons = new List<RadioButton>();
            string selectedTag = "No selection";
            foreach (Control c in directionGroup.Controls)
            {
                if (c.GetType() == typeof(RadioButton))
                {
                    buttons.Add((RadioButton)c);
                }
            }
            var selectedRb = (from rb in buttons where rb.Checked == true select rb).FirstOrDefault();
            if (selectedRb!=null)
            {
                 selectedTag = selectedRb.Tag.ToString();
            }
      
            FormattableString result = $"Selected Radio button tag ={selectedTag}";
            MessageBox.Show(result.ToString());
        }
