    _dsuser.EnforceConstraints = false;
    //fill info
    try
    {
        _dsuser.EnforceConstraints = true;
    }
    catch
    {
                if (ds.HasErrors)
                {
                    DataRow[] drs = _dsuser.[datatablename].GetErrors();
                    foreach(DataRow dr in drs)
                    {
                        foreach(DataColumn dc in dr.GetColumnsInError())
                        {
                            Console.Write(dr.GetColumnError(dc));
                        }
                    }
                }
    }
