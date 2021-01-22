    try{
        int nLineCount = Converter.SendMessage(ptrHandle, Converter.EM_GETLINECOUNT, 0, 0);
        int nIndex = Converter.SendMessage(ptrHandle, Converter.EM_LINEINDEX, nLineCount, 0);
        int nLineLen = Converter.SendMessage(ptrHandle, Converter.EM_LINELENGTH, nIndex, 0);
        //
        strBuffer = new System.Text.StringBuilder(nLineLen);
        strBuffer.Append(Convert.ToChar(nLineLen));
        strBuffer.Length = nLineLen;
        int nCharCnt = Converter.SendMessage(ptrHandle, Converter.EM_GETLINE, new IntPtr(nLineCount),     strBuffer).ToInt32();
        nLen = nCharCnt;
        if (nLen <= 0) return;
        if (nPreviousLen != nLen) nUpdated = true;
    }finally{
        source = new TextReader(strBuffer.ToString(), nUpdated, isOpen ? true : false);
        this.isOpen = true;
        nPreviousLen = nLen;
    }
