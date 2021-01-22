    long GetPhoneNumber(string PhoneNumberText)
    {
        // Returns 0 on error
        StringBuilder TempPhoneNumber = new StringBuilder(PhoneNumberText.Length);
        for (int i=0;i<PhoneNumberText.Length;i++)
        {
            if (!char.IsDigit(PhoneNumberText[i]))
                continue;
            TempPhoneNumber.Append(PhoneNumberText[i]);
        }
        
        PhoneNumberText = TempPhoneNumber.ToString();
        if (PhoneNumberText.Length == 0)
            return 0;// No point trying to parse nothing
        long PhoneNumber = 0;
        if(!long.TryParse(PhoneNumberText,out PhoneNumber))
            return 0; // Failed to parse string
        return PhoneNumber;
    }
