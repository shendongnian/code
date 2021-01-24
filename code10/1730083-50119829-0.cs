        private void stateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (newClient != null || newCompany != null || newSchool != null)
            {
                if (cliLVVisible)
                {
                    newClient.State = (string)stateComboBox.SelectedValue;
                }
                else if (comLVVisible)
                {
                    newCompany.State = (string)stateComboBox1.SelectedValue;
                }
                else if (schLVVisible)
                {
                    newSchool.State= (string)stateComboBox2.SelectedValue;
                }
            }
        }
