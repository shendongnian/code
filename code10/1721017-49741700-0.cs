    try {
       var addr = new System.Net.Mail.MailAddress(txtRecipents.Text);
       if (txtRecipents.Text == addr.Address)
       {
          // valid email address
       }
    }
    catch {
       // NOT a valid email address
    }
