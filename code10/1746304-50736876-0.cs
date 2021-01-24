                    int count = 0;
                    match = cells.Find(
                            What: what,
                            After: Type.Missing,
                            LookIn: Excel.XlFindLookIn.xlFormulas,
                            LookAt: Excel.XlLookAt.xlPart,
                            SearchDirection: Excel.XlSearchDirection.xlNext);
                    Excel.Range firstMatch = null;
                    while (match != null)
                    {
                        if (firstMatch == null)
                        {
                            firstMatch = match;
                        }
                        // If you didn't move to a new range, you are done.
                        else if (match.get_Address(Excel.XlReferenceStyle.xlA1)
                              == firstMatch.get_Address(Excel.XlReferenceStyle.xlA1))
                        {
                            break;
                        }
                        count++;
                        match = cells.FindNext(match);
                    }
                    cells.Replace(
                        what,
                        replacement,
                        Excel.XlLookAt.xlPart,
                        Excel.XlSearchOrder.xlByColumns,
                        false
                    );
                    log.Debug(xlDWorkBook.Name + "-" + xlSheet.Name + "共找到: " + count + "個「" + what + "」，並以「" + replacement + "」完成取代");
