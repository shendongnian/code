    private static int? GetColumnIndex(string cellReference)
            {
                if (string.IsNullOrEmpty(cellReference))
                {
                    return null;
                }
    
                string columnReference = Regex.Replace(cellReference.ToUpper(), @"[\d]", string.Empty);
    
                int columnNumber = -1;
                int mulitplier = 1;
    
                foreach (char c in columnReference.ToCharArray().Reverse())
                {
                    columnNumber += mulitplier * ((int)c - 64);
    
                    mulitplier = mulitplier * 26;
                }
    
                return columnNumber + 1;
            }
