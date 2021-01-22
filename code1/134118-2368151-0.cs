    /***********************************************************************
     * bool ValiText(char inChar,
     *               string valid,
     *               bool editable,
     *               bool casesensitive
     * Description: Validate Input Characters As They Are Input
     * Notes: For each control whose input you wish to validate, just put
     *        e.Handled = ValiText(e.KeyChar, "0123456789/-" [,true][,true])
     *        In The KeyPress Event
     ***********************************************************************/
    public bool ValiText(char inChar, string valid, bool editable, bool casesensitive)
    {
        string inVal = inChar.ToString();
        string tst = valid;
        /// Editable - Add The Backspace Key
        if (editable) tst += ((char)8).ToString();
        /// Case InSensitive - Make Them Both The Same Case
        if (!casesensitive)
        {
            tst = tst.ToLower();
            inVal = inVal.ToLower();
        }
        return tst.IndexOf(inVal,0,tst.Length) < 0;
    }
    public bool ValiText(char inChar, string valid, bool editable)
    {
        string tst = valid;
        /// Editable - Add The Backspace Key
        if (editable) tst += ((char)8).ToString();
        return tst.IndexOf(inChar.ToString(),0,tst.Length) < 0;
    }
    public bool ValiText(char inChar, string valid)
    {
        return valid.IndexOf(inChar.ToString(),0,valid.Length) < 0;
    }
