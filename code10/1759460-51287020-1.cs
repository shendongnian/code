    if (IsPostBack)
    {
        string ssn = txtSSN.Text.ToString();
        getMypensionListWS pensionList = new getMypensionListWS();
        myPensionerProfitList[] arrayOfPensionList = getPensionProfitList(ssn);
        radGridPensionList.DataSource = arrayOfPensionList;
    }
