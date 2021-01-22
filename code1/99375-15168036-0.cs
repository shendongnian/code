        public static string ToWrittenValueString(this decimal number)
        {
            // convert the number to a usable value
            var numStr = Math.Round(number,2,MidpointRounding.AwayFromZero).ToString();
            
            // seperate the value before and after the decimal point
            var numParts = numStr.Split('.');
            IList<string> txt = new List<string>();
            
            // get the total number of digits in the number before the decimal point.
            var digits = numParts[0].Length;
            
            for (int n = 1; n <= digits; n++)
            {
                //this handles the hundreds, hundred thousands and hundred millions place
                if (n % 3 == 0)
                {
                    txt.Add("HUNDRED");
                    txt.Add(onesAndTeens[int.Parse(numParts[0][digits - n].ToString())]);
                    
                }
                // this handles the two digits preceding the hundreds, hundred thousands and hundred millions place    
                if (n % 3 == 2 | (n == digits & n % 3!=0)) 
                {
                    // this get's the integer equivilent of only those two digits
                    var tmpnum = int.Parse(string.Join("", numParts[0].Skip(digits-n).Take(n % 3 == 2? 2: 1)));
                    
                    
                    // this get's the name of the three didget grouping that the current digit's of interest are in i.e. thousand, million etc...  
                    txt.Add(digitGroupName[((n - n % 3) / 3)]);
                    // if the integer equivilent is less than 20 we use the onesAndTeens lookup table
                    // if the integer equivilent is twenty or more we use the tens lookup for the most significant digit and the onesAndTeens lookup for the least significant digit
                    if (tmpnum < 20)
                        txt.Add(onesAndTeens[tmpnum]); 
                    else
                        txt.Add(string.Format("{0}{1}", tens[(tmpnum - tmpnum % 10) / 10], onesAndTeens[tmpnum % 10] ));
                }
                    
            }
           
            return  string.Format("{0} AND {1}/100 DOLLARS", string.Join(" ", txt.Reverse()), numParts[1]);;
        }
        private static string[] onesAndTeens = new string[20] { "", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT","NINE","TEN","ELEVEN","TWELVE", "THIRTEEN","FOURTEEN","FIFTEEN","SIXTEEN","SEVENTEEN","EIGHTEEN","NINETEEN"};
        private static string[] tens = new string[10] {"","","TWENTY","THIRTY","FOURTY","FIFTY","SIXTY","SEVENTY","EIGHTY","NINETY"};
        private static string[] digitGroupName = new string[4] {"","THOUSAND","MILLION","BILLION" };
