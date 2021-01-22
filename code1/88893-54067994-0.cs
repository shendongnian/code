    private decimal TruncateToTwoDecimals(string value)
            {
                int error_ReturnZeroIfThisIsOne = 0;
                int tempArrayLength = value.Length;
                char[] tempArray = new char[tempArrayLength];
                int startCount = 0; //starts the counter when it hits punctuation
                int newCounter = 0; //counts twice to ensure only two decimal places after the comma/period
                int nextArraySize = 1; //gets the size spec ready for the return array/next array (needs to be + 1)
                int tempArrayCurrentIndex = 0;
                foreach (Char thisChar in value)
                {
                    tempArray[tempArrayCurrentIndex] = thisChar;
                    tempArrayCurrentIndex++;
                }
                for (int i = 0; i < tempArrayLength; i++)
                {
                    if (tempArray[i].ToString() == "," || tempArray[i].ToString() == ".")
                    {
                        startCount = 1;
                    }
                    if (startCount == 1)
                    {
                        newCounter++;
                    }
                    if (newCounter > 2)
                    {
                        break;
                    }
                    nextArraySize++;
                }
                char[] returnArray = new char[nextArraySize];
                int tempErrorCheckBelow = 0;
                for (int i = 0; i < nextArraySize; i++)
                {
                    try
                    {
                        returnArray[i] = tempArray[i]; //left array will read [i] till the spot in right array where second decimal and ignore the rest. snip snip
                    }
                    catch (Exception)
                    {
                        if (tempErrorCheckBelow == 2)
                        {
                            MessageBox.Show("OutOfBounds", "Error_ArrayIndex Out Of Bounds @TTTD");
                        }
                        returnArray[i] = Convert.ToChar("0");
                        tempErrorCheckBelow++;
                    }
                }
                if (tempArrayLength < 1)
                {
                    error_ReturnZeroIfThisIsOne++;
                    string tempString = "0.0";
                    try
                    {
                        decimal tempDecimal = Decimal.Parse(tempString);
                        return tempDecimal;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error_input String received Incorrect Format @TTTD");
                        return 0.00m;
                    }
                }
                else
                {
                    error_ReturnZeroIfThisIsOne++;
                    string tempString = " ";
                    tempString = new string(returnArray);
                    try
                    {
                        decimal tempDecimal = Decimal.Parse(tempString);
                        return tempDecimal;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error_inputString _0_ @TTTD");
                        return 0m;
                        
                    }
                }
            }
