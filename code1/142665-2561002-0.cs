    private int _id = -1;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["PhoneId"] != null)
        _id = SafeConvert.ToInt(ViewState["PhoneId"]);
    }
    
    protected override object SaveViewState()
    {
        ViewState["PhoneId"] = _id;
        return base.SaveViewState();
    }
    
    public Phone GetPhone()
    {
        Phone phone = new Phone();
        phone.Id = _id;
        phone.AreaCode = SafeConvert.ToInt(txt_areaCode.Text);
        phone.Number = SafeConvert.ToInt(txt_number.Text);
        return phone;
    }
