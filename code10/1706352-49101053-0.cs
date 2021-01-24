           if(ValidateDate(starttime,endtime,out outmessage) && ValidateData(txtBookingName.Text,txtUserID.Text, txtUserName.Text, ddlClub.SelectedValue, ddlPitches.SelectedValue , end.Value , start.Value ,txtDescription.Text, out outmessage))
           {
                // all valid 
               lblMessage.Text=outmessage;
            }
          else
           {
                 //something is wrong.
               MessageBox.Show(outmessage);
           }
 
     }
