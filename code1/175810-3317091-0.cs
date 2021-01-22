    public void SeparateDataWrite()
    {
      if (m_strStandardEntryClassCode == "PPD")
      {
        m_strPath += "/PPD_BatchHeader_" + m_strDate + ".txt";
      }
      else
      {
        m_strPath += "/CCD_BatchHeader_" + m_strDate + ".txt";
      }
   
      using (StreamWriter w = File.Open(m_strPath, FileMode.Create)
      {
        WriteData(w);
        w.close();
      }
    }
    
    public MergedDataWrite()
    {
      using (StreamWriter w = File.Append("somefilename.txt")
      {
        WriteData(w);
        w.Close();
      }
    }
    public void WriteData(TextWriter tw)
    {
                tw.Write(m_strRecordTypeCode.PadLeft(1, '0'));
                tw.Write(m_strServiceClassCode.PadLeft(3, '0'));
                tw.Write(m_strCompanyName.PadRight(16, ' '));
                tw.Write(m_strCompanyDiscretionaryData.PadRight(20, ' '));
                tw.Write(m_strCompanyIdentification.PadRight(10, ' '));
                tw.Write(m_strStandardEntryClassCode.PadRight(3, ' '));
                tw.Write(m_strCompanyEntryDescription.PadRight(10, ' '));
                tw.Write(m_strCompanyDescriptiveDate.PadLeft(6, '0'));
                string m_strEffDate = m_strEffectiveEntryDate.Replace("/", "");
                tw.Write(m_strEffDate.PadLeft(6, '0'));
                tw.Write(m_strOriginatorStatusCode.PadRight(1, ' '));
                tw.Write(m_strOriginationDFIIdentification.PadLeft(8, '0'));
                tw.Write(m_strBatchNumber.PadLeft(7, '0'));
                tw.Flush();
    }
