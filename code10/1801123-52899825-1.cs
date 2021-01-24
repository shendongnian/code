      private List<string> selectedBoxes()
        {
            List<string> checkBoxText = new List<string>();
            var boxes = new CheckBox[] { checkBox1, checkBox2, checkBox3 };
            foreach (var box in boxes)
            {
                if (box.Checked == true)
                {
                    checkBoxText.Add(box.Text);
                }
            }
            return checkBoxText;
        }
        public void ShowMessage()
        {
            var selectedCheckboxes = selectedBoxes();
            MessageBox.Show(string.Join(",", selectedCheckboxes));
        }
