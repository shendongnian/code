    public override void ItemAdding(SPItemEventProperties properties)
    {
        base.ItemAdding(properties);
        // only perform if we have an Email column
        if (properties.AfterProperties["Email"] != null)
        {
            // test to see if the email is valid
            if (!IsValidEmailAddress(properties.AfterProperties["Email"].ToString()))
            {
                // email validation failed, so display an error
                properties.Status = SPEventReceiverStatus.CancelWithError;
                properties.Cancel = true;
                properties.ErrorMessage = "Please enter a valid email address";
                
            }
        }
        
    }
