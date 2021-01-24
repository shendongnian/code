        private double SumTextBoxesValues()
        {
            double sum = 0;
            foreach (TabPage tbp in tabControl1.TabPages)
            {
                var textBoxes = GetAllTextBoxes(tbp);
                foreach (var textBox in textBoxes)
                {
                    if(double.TryParse(textBox.Text, out double value))
                        sum += value;
                }
            }
            return sum;
        }
        private static IEnumerable<TextBox> GetAllTextBoxes(Control container)
        {
            var controlList = new List<TextBox>();
            foreach (Control c in container.Controls)
            {
                controlList.AddRange(GetAllTextBoxes(c));
                if(c is TextBox box)
                    controlList.Add(box);
            }
            return controlList;
        }
