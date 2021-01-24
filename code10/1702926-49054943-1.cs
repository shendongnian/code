        if (destObject is PdfArray arr)
        {
            if (arr.Get(0) is PdfDictionary pageDict)
            {
                int pageNumber = document.GetPageNumber(pageDict);
                [...]
            }
            [... inspect remaining array entries ...]
        }
    }
