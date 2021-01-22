    protected void Page_Load(object sender, EventArgs e)
    {
        if (_controlListToBind != null && _controlListToBind.Count > 0)
        {
            NumberOfControls = _controlListToBind.Count;
            int index = 0;
            foreach (Address address in _controlListToBind)
            {
                AddressInfo addressInfo = (AddressInfo)LoadControl("AddressInfo.ascx");
                addressInfo.ID = String.Format("AddressInfo{0}", index++);
                addressInfo.InitControl(Editable, address);
                plc_infoCtrls.Controls.Add(addressInfo);
            }
        }
        else
        {
            if (NumberOfControls <= 0)
                NumberOfControls = 1;
            for (int i = 0; i < NumberOfControls; i++)
            {
                AddressInfo addressInfo = (AddressInfo)LoadControl("AddressInfo.ascx");
                addressInfo.ID = String.Format("AddressInfo{0}", i);
                addressInfo.InitControl(Editable, null);
                plc_infoCtrls.Controls.Add(addressInfo);
            }
        }
        RefreshButtons();
    }
