           protected override void InitView(View view)
            {
               approveCheckBox = 
              (CheckBox)view.FindViewById(Resource.Id.approvedCheckBox);
                rejectCheckBox = 
                (CheckBox)view.FindViewById(Resource.Id.rejectedCheckBox);
    
                approveCheckBox.CheckedChange += (s, e) =>
                {
                    if (approveCheckBox.Checked)
                    {
                        rejectCheckBox.Enabled = false;
                    }
                    else
                    {
                        rejectCheckBox.Enabled = true;
                    }
                };
    
                rejectCheckBox.CheckedChange += (s, e) =>
                {
                    if (rejectCheckBox.Checked)
                    {
                        approveCheckBox.Enabled = false;
                    }
                    else
                    {
                        approveCheckBox.Enabled = true;
                    }
                };
            }
