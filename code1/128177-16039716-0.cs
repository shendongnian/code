    NCKHSV_TTD54TableAdapters.adtReportGiangVienTableAdapter tableAdapter = new 
    NCKHSV_TTD54TableAdapters.adtReportGiangVienTableAdapter();//Create a TableAdapter to using.
     tableAdapter.Connection.ConnectionString = strConn;//change ConnectionString to strConn
     tableAdapter.ClearBeforeFill = true;
     tableAdapter.Fill(dataset.adtReportGiangVien);
