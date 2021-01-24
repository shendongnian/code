     Sheets worksheets = Globals.ThisAddIn.Application.ActiveWorkbook.Sheets;
                int wsCount = worksheets.Count;
                for (int w = 1; w <= wsCount; w++)
                {                    
                    Worksheet currentWorksheet = worksheets.Item[w] as Worksheet;                       
                        string mysheet = currentWorksheet.Name;                    
                        tickerRange = null;
                        tickerRange = currentWorksheet.Range["A6:A1000", Type.Missing]; //location of ticker symbols
                        if (Array.IndexOf(accountList.ToArray(), mysheet) >= 0)
                        {
                            //for every row in the specified range
                            //foreach (Range row in currentWorksheet.Range["A6:A1000", Type.Missing]) //for every row inside the tickerRange variable
                            for (int r = 6; r <=1000; r++)
                            {
                                try
                                {
                                    badValue = false;
                                    Range row = null;
                                    row = currentWorksheet.Range["A" + r];                                    
                                    quoteCell = null;
                                    //quoteCell = currentWorksheet.Range["A6:A1000", Type.Missing];
                                    //quoteCell = quoteCell.Range[row.Offset[0, 5], Type.Missing];
                                    quoteCell = row.Offset[0, 5]; //location where market price will be inserted
                                    string currentStock = row.Value2; //set ticker Symbol equal to the cell of the range element                            
                                    if (string.IsNullOrEmpty(currentStock) || currentStock.Trim().Length > 4) //if there is nothing in the cell or the length is more than 4 characters, don't call the fetchPrice.
                                    {
                                        badValue = true;
                                    }//end if
                                    else if (Regex.IsMatch(currentStock, "[ ]|[0-9]")) //if the cell has whitespace or numbers, don't call fetchPrice. This would result in bad output
                                    {
                                        badValue = true;
                                    }
                                    else
                                    {
                                        currentStock = currentStock.ToUpper();
                                    }
                                    if (!badValue) //if the dictionary contains the ticker symbol, no need to call fetchPrice again this loop, just get the value out of dictionary
                                    {
                                        price = tickerDictionary[currentStock];
                                        quoteCell.Value2 = price;
                                        //volumeCell.Value2 = (stockObject.minuteVolume / stockObject.currentVolume)*100;
                                        //break;
                                    }
                                } //end try
                                catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException rbe) //i forget why i had to catch this in the first place. but it came up once, and now it's caught. so there's that. 
                                {
                                    Console.WriteLine("Runtime Binder Exception caught");
                                }//end catch
                                catch (System.Runtime.InteropServices.COMException ce)
                                {
                                    stopTicker();
                                }
                                /*if a KeyNotFound exception was thrown, it was because the user entered a new stock symbol while the loop was running, but
                                AFTER assemblePrice() was called. This results in the dictionary being asked for something it doesn't have. Just run assemblePrice() again. 
                                */
                                catch (System.Collections.Generic.KeyNotFoundException knfe) 
                                {                                
                                assemblePrice(); 
                                }
                            } //end for
                        }
                    
                    Console.WriteLine("For Loop Completed");
                    Console.WriteLine("Sleep Started for " + restartTime + "seconds");
                    //if the timerbox is empty, is set to 5 or less, or contains non-numeric characters
                    if (string.IsNullOrEmpty(timerBox.Text) || Regex.Equals(timerBox.Text, "[0-5]") || Regex.IsMatch(timerBox.Text, "[^0-9]"))
                    {
                        restartTime = 10;
                    }//end else
                    else
                    {
                        restartTime = Convert.ToInt32(timerBox.Text); //restartTime gets the value after string contents of timerBox are cast to int.
                    }//end else
                }//bigger for loop done
