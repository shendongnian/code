    public static void UpdateHUD (FrmModuleHost frm, UpdateData  data)
    {
        if (!string.IsNullOrEmpty(data.FirstName) {
        frm.tbxHUD_LastName.Text = data.FirstName;
        _lastName = data.FirstName;
        }
    
        if (!string.IsNullOrEmpty(data.LastName) {
        frm.tbxHUD_FirstName.Text = data.LastName;
        _firstName = data.FirstName;
        }
        if (!string.IsNullOrEmpty(data.MiddleName) {
        frm.tbxHUD_MiddleName.Text = data.MiddleName;
        _middleName = data.FirstName;
        }
