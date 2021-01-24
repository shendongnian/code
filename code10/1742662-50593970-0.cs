    private static Boolean IsValidRecord(String[] strFields)
    {
        Boolean blnOK = true;
        Boolean bln0OK = true;
        Boolean bln1OK = true;
        Boolean bln2OK = true;
        Boolean bln3OK = true;
        Boolean bln4OK = true;
        Decimal decCheck;
        //Check all fields that must be validated
        if (String.IsNullOrWhiteSpace(strFields[0]))
        {
            Boolean bln0OK = false;
            Console.WriteLine("Error: Unable to Parse First Name!");
        }
        else
        {
            bln0OK = true;
        }
        if (String.IsNullOrWhiteSpace(strFields[1]))
        {
            bln1OK = false;
            Console.WriteLine("Error: Unable to Parse Middle Initial!");
        }
        else
        {
            bln1OK = true;
        }
        if (String.IsNullOrWhiteSpace(strFields[2]))
        {
            bln2OK = false;
            Console.WriteLine("Error: Unable to Parse Last Name!");
        }
        else
        {
            bln2OK = true;
        }
            if (strFields[3].Length == 9)
            {
                    bln3OK = true;
            }
            else
            {
                bln3OK = false;
                Console.WriteLine("Error: Unable to Parse SSAN!");
            }
        if (strFields[4] == null)
        {
            bln4OK = false;
        }
        else
        {
            if (Decimal.TryParse(strFields[4], out decCheck))
            {
                bln4OK = true;
            }
            else
            {
                bln4OK = false;
                Console.WriteLine("Error: Unable to Parse PayRate!");
            }
        }
        blnOK = bl0OK && bl1OK && bl2OK && bl3OK && bl4OK; 
        return blnOK;
    }
