    _bsHeader.EndEdit();
    if (_dsHeader.HasChanges())
    {
    DataTable dsInsert = _dsHeader.GetChanges(DataRowState.Added).Copy();
    _objDal.Insert(dsInsert);
    }
