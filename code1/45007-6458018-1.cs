    static void SuppressUserPropertyPrinting(Outlook.MailItem message)
    {
        try
        {   // Late Binding in .NET: https://support.microsoft.com/en-us/kb/302902
            Type userPropertyType;
            long dispidMember = 107;
            long ulPropPrintable = 0x4; // removes PDO_PRINT_SAVEAS
            string dispMemberName = String.Format("[DispID={0}]", dispidMember);
            object[] dispParams;
    
            if (message.UserProperties.Count == 0) return; // no props found (exit)
    
            // marks all user properties as suppressed
            foreach (Outlook.UserProperty userProperty in message.UserProperties.Cast<Outlook.UserProperty>())
            {
                if (userProperty == null) continue; // no prop found (go to next)
                userPropertyType = userProperty.GetType(); // user property type
    
                // Call IDispatch::Invoke to get the current flags
                object flags = userPropertyType.InvokeMember(dispMemberName, BindingFlags.GetProperty, null, userProperty, null);
                long lFlags = long.Parse(flags.ToString()); // default is 45 - PDO_IS_CUSTOM|PDO_PRINT_SAVEAS|PDO_PRINT_SAVEAS_DEF (ref: http://msdn.microsoft.com/en-us/library/ee415114.aspx)
    
                // Remove the hidden property Printable flag
                lFlags &= ~ulPropPrintable; // change to 41 - // PDO_IS_CUSTOM|PDO_PRINT_SAVEAS_DEF (ref: http://msdn.microsoft.com/en-us/library/ee415114.aspx)
    
                // Place the new flags property into an argument array
                dispParams = new object[] { lFlags };
    
                // Call IDispatch::Invoke to set the current flags
                userPropertyType.InvokeMember(dispMemberName, BindingFlags.SetProperty, null, userProperty, dispParams);
            }
        }
        catch { } // safely ignore if property suppression doesn't work
    }
