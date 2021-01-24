    if (IsPostBack)
    {
        var list = new List<myPensionerProfitList>();
        string ssn = txtSSN.Text.ToString();
        getMypensionListWS pensionList = new getMypensionListWS();
        myPensionerProfitList[] arrayOfPensionList = getPensionProfitList(ssn);
        for (int i = 0; i < arrayOfPensionList.Length; i++)
        {
            myPensionerProfitList item = arrayOfPensionList[i];
            list.Add(item);
        }
        radGridPensionList.DataSource = list;
    }
