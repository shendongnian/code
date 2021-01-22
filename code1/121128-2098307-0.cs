    public void ExportPaychecks(HeaderFormatter h, CheckRowFormatter f)
    {
       var pays = _pays.GetPaysForCurrentDate();
       foreach (PayObject pay in pays)
       {
          h.formatHeader(pay);
          f.WriteDetailRow(pay);
       }
    }
