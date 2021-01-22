        /// <summary>
        /// Get the integer part of any decimal number passed trough a string 
        /// </summary>
        /// <param name="decimalNumber">String passed</param>
        /// <returns>teh integer part , 0 in case of error</returns>
        private int GetIntPart(String decimalNumber)
        {
            if(!Decimal.TryParse(decimalNumber, NumberStyles.Any , new CultureInfo("en-US"), out decimal dn))
            {
                MessageBox.Show("String " + decimalNumber + " is not in corret format", "GetIntPart", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(int);
            } 
            
            return Convert.ToInt32(Decimal.Truncate(dn));
        }
