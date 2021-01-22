    public static string ConvertToAlphaColumnReferenceFromInteger(int columnReference)
        {
            int baseValue = ((int)('A')) - 1 ;
            string lsReturn = String.Empty; 
 
            if (columnReference > 26) 
            {
                lsReturn = ConvertToAlphaColumnReferenceFromInteger(Convert.ToInt32(Convert.ToDouble(columnReference / 26).ToString().Split('.')[0]));
            } 
 
            return lsReturn + Convert.ToChar(baseValue + (columnReference % 26));            
        }
