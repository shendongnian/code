        private void OnSave()
        {
          if(ValidateData())
          {
            //do save
          }
        }
        public bool ValidateData()
        {
            errorProvider.Clear();
            bool valid = true;
            if (this.defectStatusComboBox.SelectedIndex == -1)
            {
                errorProvider.SetError(defectStatusComboBox, "This is a required feild.");
                valid = false;
            }
            //etc...
            return valid;
         }
