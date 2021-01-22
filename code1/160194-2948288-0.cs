    private void SetControlNumbers()
    {
        string controlString = "";
        int numberLength = PersonNummer.Length;
        switch (numberLength)
        {
            case (10) :
                controlString = PersonNummer.Substring(6, 4);
                break;
            case (11) :
                controlString = PersonNummer.Substring(7, 4);
                break;
            case (12) :
                controlString = PersonNummer.Substring(8, 4);
                break;
            case (13) : 
                controlString = PersonNummer.Substring(9, 4);
                break;
            default:
                //decide what to do here, 
                //could do this or something more appropriate for your situation
                throw new NotSupportedException("An invalid PersonNummer.Length value was encountered.")
        }
        ControlNumbers = Convert.ToInt32(controlString);
    }
