        private void ClientRegistrationForm_Load(object sender, EventArgs e)
        {
            var comboxes=_Helper.GetAllControls(this, typeof(ComboBox)).ToList();
            if (comboxes != null)
            {
                foreach (ComboBox item in comboxes)
                {
                    item.SelectedIndexChanged +=new EventHandler(this.ChangeComboFocus) ;
                }
            }
        }
        
