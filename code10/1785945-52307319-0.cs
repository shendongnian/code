    public class MoneyExt
    {
        public string ConvertNumberToENG(int amount)
        {
            var dollars, cents, temp;
            var decimalPlace, count;
            string[] place = new string[10];
            place[2] = " Thousand ";
            place[3] = " Million ";
            place[4] = " Billion ";
            place[5] = " Trillion ";
    
            // String representation of amount.
            amount = amount.Trim();
            amount = amount.Replace(",", "");
            // Position of decimal place 0 if none.
            decimalPlace = amount.IndexOf(".");
            // Convert cents and set string amount to dollar amount.
            if (decimalPlace > 0)
            {
                cents = GetTens(ref amount.Substring(decimalPlace + 1).PadRight(2, "0").Substring(0, 2));
                amount = amount.Substring(0, decimalPlace).Trim();
            }
    
            count = 1;
            while (amount != "")
            {
                temp = GetHundreds(amount.Substring(Math.Max(amount.Length, 3) - 3));
                if (temp != "")
                    dollars = temp + place[count] + dollars;
                if (amount.Length > 3)
                    amount = amount.Substring(0, amount.Length - 3);
                else
                    amount = "";
                count = count + 1;
            }
    
            switch (dollars)
            {
                case "One":
                    {
                        dollars = "One Bath";
                        break;
                    }
    
                default:
                    {
                        dollars = dollars + " Bath";
                        break;
                    }
            }
    
            // Select Case cents
            // ' Case ""
            // '     cents = " and No Cents"
            // Case "One"
            // cents = " and One Satang"
            // Case Else
            // cents = " and " & cents & " Satang"
            // End Select
    
            ConvertNumberToENG = dollars + cents;
        }
    
        // Converts a number from 100-999 into text
        public string GetHundreds(string amount)
        {
            string Result;
            if (!int.Parse(amount) == 0)
            {
                amount = amount.PadLeft(3, "0");
                // Convert the hundreds place.
                if (amount.Substring(0, 1) != "0")
                    Result = GetDigit(ref amount.Substring(0, 1)) + " Hundred ";
                // Convert the tens and ones place.
                if (amount.Substring(1, 1) != "0")
                    Result = Result + GetTens(ref amount.Substring(1));
                else
                    Result = Result + GetDigit(ref amount.Substring(2));
                GetHundreds = Result;
            }
        }
    
        // Converts a number from 10 to 99 into text.
        private string GetTens(ref string TensText)
        {
            string Result;
            Result = "";           // Null out the temporary function value.
            if (TensText.StartsWith("1"))
            {
                switch (int.Parse(TensText))
                {
                    case 10:
                        {
                            Result = "Ten";
                            break;
                        }
    
                    case 11:
                        {
                            Result = "Eleven";
                            break;
                        }
    
                    case 12:
                        {
                            Result = "Twelve";
                            break;
                        }
    
                    case 13:
                        {
                            Result = "Thirteen";
                            break;
                        }
    
                    case 14:
                        {
                            Result = "Fourteen";
                            break;
                        }
    
                    case 15:
                        {
                            Result = "Fifteen";
                            break;
                        }
    
                    case 16:
                        {
                            Result = "Sixteen";
                            break;
                        }
    
                    case 17:
                        {
                            Result = "Seventeen";
                            break;
                        }
    
                    case 18:
                        {
                            Result = "Eighteen";
                            break;
                        }
    
                    case 19:
                        {
                            Result = "Nineteen";
                            break;
                        }
    
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                switch (int.Parse(TensText.Substring(0, 1)))
                {
                    case 2:
                        {
                            Result = "Twenty ";
                            break;
                        }
    
                    case 3:
                        {
                            Result = "Thirty ";
                            break;
                        }
    
                    case 4:
                        {
                            Result = "Forty ";
                            break;
                        }
    
                    case 5:
                        {
                            Result = "Fifty ";
                            break;
                        }
    
                    case 6:
                        {
                            Result = "Sixty ";
                            break;
                        }
    
                    case 7:
                        {
                            Result = "Seventy ";
                            break;
                        }
    
                    case 8:
                        {
                            Result = "Eighty ";
                            break;
                        }
    
                    case 9:
                        {
                            Result = "Ninety ";
                            break;
                        }
    
                    default:
                        {
                            break;
                        }
                }
                Result = Result + GetDigit(ref TensText.Substring(1, 1));  // Retrieve ones place.
            }
            GetTens = Result;
        }
    
        // Converts a number from 1 to 9 into text.
        private string GetDigit(ref string Digit)
        {
            switch (int.Parse(Digit))
            {
                case 1:
                    {
                        GetDigit = "One";
                        break;
                    }
    
                case 2:
                    {
                        GetDigit = "Two";
                        break;
                    }
    
                case 3:
                    {
                        GetDigit = "Three";
                        break;
                    }
    
                case 4:
                    {
                        GetDigit = "Four";
                        break;
                    }
    
                case 5:
                    {
                        GetDigit = "Five";
                        break;
                    }
    
                case 6:
                    {
                        GetDigit = "Six";
                        break;
                    }
    
                case 7:
                    {
                        GetDigit = "Seven";
                        break;
                    }
    
                case 8:
                    {
                        GetDigit = "Eight";
                        break;
                    }
    
                case 9:
                    {
                        GetDigit = "Nine";
                        break;
                    }
    
                default:
                    {
                        GetDigit = "";
                        break;
                    }
            }
        }
    }
