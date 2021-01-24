    //First create a function only for validating
    //This is your code to almost all - variable names change  
    public Boolean validateGTIN(string gtin)
        {
            Boolean IsValid = false;
            int Sum = 0;
            int EvenSum = 0;
            int CurrentDigit = 0;
            for (int pos = 0; pos <= 12; ++pos)
            {                
                Int32.TryParse(gtin[pos].ToString(), out CurrentDigit);
                if (pos % 2 == 0)
                {                    
                    EvenSum += CurrentDigit;
                }                    
                else
                {
                    Sum += CurrentDigit;
                }                    
            }
            Sum += 3 * EvenSum;
            Int32.TryParse(GTIN[13].ToString(), out CurrentDigit);
            IsValid = ((10 - (Sum % 10)) % 10) == CurrentDigit;
            if (!IsValid)
            {
                Console.Write("GTIN code is invalid (wrong checksum)");
            }
            return IsValid;
        }
    //Here we change quite a bit to accommodate for edge cases:
    //We return a string which is the GTIN fully formed or we throw and exception.
    public String createGTIN(string bcFromBackend)
        {
            string barcodeStr = bcFromBackend;
    //Here we check if the barcode supplied has fewer than 13 digits
            if (barcodeStr.Length < 13)
            {
                throw new System.ArgumentException("Barcode not an EAN-13 
                barcode");
            }
            //If the barcode is of length 13 we start feeding the value with a padded 0 
            //into our validate fuction if it returns false then we pad with 1 and so on
            //until we get to 9. It then throws an error if not valid  
            else if (barcodeStr.Length == 13)
            {
                if(validateGTIN("0"+ barcodeStr))
                {
                     return "0" + barcodeStr;
                } 
                else if(validateGTIN("1" + barcodeStr))
                {
                     return "1" + barcodeStr;
                }
                else if(validateGTIN("2" + barcodeStr))
                {
                     return "2" + barcodeStr;
                }  
                else if(validateGTIN("3" + barcodeStr))
                {
                     return "3" + barcodeStr;
                }
                else if(validateGTIN("4" + barcodeStr))
                {
                     return "4" + barcodeStr;
                }
                else if(validateGTIN("4" + barcodeStr))
                {
                     return "4" + barcodeStr;
                }
                else if(validateGTIN("5" + barcodeStr))
                {
                     return "5" + barcodeStr;
                }
                else if(validateGTIN("6" + barcodeStr))
                {
                     return "6" + barcodeStr;
                }
                else if(validateGTIN("7" + barcodeStr))
                {
                     return "7" + barcodeStr;
                }
                else if(validateGTIN("8" + barcodeStr))
                {
                     return "8" + barcodeStr;
                }
                else if(validateGTIN("9" + barcodeStr))
                {
                     return "9" + barcodeStr;
                } else {
                     throw new System.InvalidOperationException("Unable to create valid 
                     GTIN from given barcode")
                }
            }
            //Lastly if the barcode is of length 14 we try with this value. Else throw 
            //error
            else if(barcodeStr.Length == 14)
            {
                if(validateGTIN(barcodeStr)
                {
                     return barcodeStr;
                }
                else
                {
                     throw new System.InvalidOperationException("Unable to create valid 
                     GTIN from given barcode");
                }
            }
