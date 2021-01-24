        //To remove all the duplicate lines in the result file
        private void RemoveDuplicateRecords()
        {
            try
            {
                foreach (Excel.Worksheet worksheet in bookDest.Worksheets)
                {
                    if (worksheet.AutoFilter != null)
                        worksheet.AutoFilterMode = false;
                    long n = worksheet.UsedRange.Columns.Count;
                    Excel.Range range = worksheet.UsedRange;
                    range.Select();
                    range.Activate();
                    range.RemoveDuplicates(BuildColAry(n), Excel.XlYesNoGuess.xlYes);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        dynamic BuildColAry(long n)
        {
            dynamic vMyArray = new dynamic[n];
            int idx;
            for (idx = 1; idx <= n; idx++)
            {
                vMyArray[idx - 1] = idx;
            }
            return vMyArray;
        }
