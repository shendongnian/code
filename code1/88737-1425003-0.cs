    public void ShowAllFly()
    {
        Invoke((MethodsInvoker) delegate {
            cbFly.Items.Clear();
            cbFly.Items.Add("Uçuş Seçiniz...");
            dsFlyTableAdapters.tblFlyTableAdapter _t =
                new KTHY.dsFlyTableAdapters.tblFlyTableAdapter();
            dsFly _mds = new dsFly();
            _mds.EnforceConstraints = false;
            dsFly.tblFlyDataTable _m = _mds.tblFly;
            _t.Fill(_m);
            foreach (DataRow _row in _m.Rows)
            {
                cbFly.Items.Add(_row["FlyID"].ToString() + "-" +
                                _row["FlyName"].ToString() + "-" +
                                _row["FlyDirection"].ToString() + "-" +
                                _row["FlyDateTime"].ToString());
            }
            //_Thread.Abort(); // WHY ARE YOU TRYING TO DO THIS?
            timer1.Enabled = false;
            WaitPanel.Visible = false;
        } );
    }
