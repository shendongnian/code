            public void lookForMe(IRibbonControl control)
        {
            Office.IMsoContactCard card = control.Context as Office.IMsoContactCard;
            string email = GetSmtpAddress(card);
            if (email != null)
            {
                System.Diagnostics.Process.Start("https://org.ad.com/" + email);
            }
        }
        private string GetSmtpAddress(Office.IMsoContactCard card)
        {
            if (card.AddressType == Office.MsoContactCardAddressType.msoContactCardAddressTypeOutlook)
            {
                Microsoft.Office.Interop.Outlook.Application host = Globals.ThisAddIn.Application;
                Microsoft.Office.Interop.Outlook.AddressEntry ae = host.Session.GetAddressEntryFromID(card.Address);
                if ((ae.AddressEntryUserType == Microsoft.Office.Interop.Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry 
                    || ae.AddressEntryUserType == Microsoft.Office.Interop.Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry))
                {
                    Microsoft.Office.Interop.Outlook.ExchangeUser ex = ae.GetExchangeUser();
                    return ex.PrimarySmtpAddress;
                }
                else
                    throw new System.Exception("unvalid address entry not found.");
            }
            else
                return card.Address;
        }
