    public void ValidateBoxes(object sender, ServerValidateEventArgs e)
            {
                if (string.IsNullOrEmpty(pics.Text) && string.IsNullOrWhiteSpace(vids.Text))
                    e.IsValid = false;
                else
                    e.IsValid = true;
            }
