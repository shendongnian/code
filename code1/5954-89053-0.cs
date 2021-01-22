    if (e.Cancelled)
    {
        statusText.Text = "Cancelled";
    }
    else if (e.Error != null) 
    {
        statusText.Text = "Exception Thrown";
    }
    else 
    {
        statusText.Text = "Completed";
    }
