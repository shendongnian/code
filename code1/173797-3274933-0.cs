    private void showAgencyFrm()
        {
            if (agentActivated())
            {
                agencyFrm.Visible = Visible;
                companynameValidator.Enabled = companyphoneValidator.Enabled = companyaddressValidator.Enabled = postcodeValidator.Enabled = true;
            }
            else
            {
                agencyFrm.Visible = false;
                companynameValidator.Enabled = companyphoneValidator.Enabled = companyaddressValidator.Enabled = postcodeValidator.Enabled = false;
            }
        }
