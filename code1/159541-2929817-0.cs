    OnValidating(object sender, ServerValidateEventArgs e)
    {
     if(CertainTextBox.Text.IsNullOrEmpty() && CertainRecordDoesNotExistInDB))
    {
     // validate
    // and set e.Valid to the desired validation output
    }
    else
    {
     e.IsValid = false;
    }
    }
