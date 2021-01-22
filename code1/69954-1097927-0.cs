       private IList<CheckBox> options= new List<CheckBox>();
        private void UpdateTTip()
        {
            toolTip1.RemoveAll();
            foreach (CheckBox c in options)
            {
                if (c.Checked)
                    toolTip1.SetToolTip(c, c.Tag.ToString());
            }
        }
