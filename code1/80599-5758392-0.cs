    string PR_MAIL_HEADER_TAG = "http://schemas.microsoft.com/mapi/proptag/0x007D001E";
    Outlook.PropertyAccessor oPropAccessor = mItemProp.PropertyAccessor;
    string strHeader = (string)oPropAccessor.GetProperty(PR_MAIL_HEADER_TAG);
    if (strHeader == "")
    {
        // MAIL IS OF TYPE SENTBOX
    }
    else
    {
       // MAIL IS OF TYPE INBOX
    }
