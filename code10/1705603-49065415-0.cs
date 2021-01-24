    using System.Globalization;
    private void DecimalFormating()
    {
        double input = 1000145.14563;
    
        NumberFormatInfo nfi = new NumberFormatInfo();
    
        //Need for grouping, so the thousendgrouping starts on the left side
        int gs = input.ToString().Split('.')[0].Length % 3;
    
        //First int in GroupSize[] is for the most right digits before the DecimalSeperator
        int[] GroupSizes = {gs, 3};
        nfi.NumberGroupSizes = GroupSizes;
    
        //Change other custom informations
        nfi.NumberDecimalDigits = 3;
        nfi.NumberDecimalSeparator = ",";
        nfi.NumberGroupSeparator = ".";
    
        string output = input.ToString("N", nfi);
    }
