        public void ChangeSelection(string name)
        {
            if (this.Controls.ContainsKey(name))
            {
                RadioButton radio1 = this.Controls[name] as RadioButton;
                radio1.IsSelected = !radio1.IsSelected;
            }
        }
