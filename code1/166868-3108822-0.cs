    (from p in new System.Collections.Generic.Dictionary<string, bool>
    {
    	{ "rowAddress", value },
    	{ "rowTaxpayerID", !value },
    	{ "rowRegistrationReasonCode", !value },
    	{ "rowAccountID", !value },
    	{ "rowAccountIDForeign", value },
    	{ "rowBankAddress", value },
    	{ "rowBankID", !value },
    	{ "rowBankSwift", value },
    	{ "rowBankAccountID", !value }
    }
    let c = this.FindControl(p.Key)
    where c != null
    select new // pseudo KeyValuePair
    {
    	Key = c,
    	Value = p.Value
    }).ForEach(p => p.Key.Visible = p.Value); // using own ext. method
