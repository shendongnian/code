    public string CCAvenueItemList
    {
        get
        {
            StringBuilder CCAvenueItems = new StringBuilder();
            DataTable dt = new DataTable();
            DataTable dtClientInfo = new DataTable();
            dt = (DataTable)Session["CheckedItems"];
            dtClientInfo = (DataTable)Session["ClientInfo"];
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
               
                string amountTemplate = "<input type=\"hidden\" name=\"Amount\" value=\"$Amount$\" />\n";
                string orderTemplate = "<input type=\"hidden\" name=\"Order_Id\" value=\"$Order_Id$\" />\n";
                // BILLING INFO
                string billingNameTemplate = "<input type=\"hidden\" name=\"billing_cust_name\" value=\"$billing_cust_name$\" />\n";
                string billingCustAddressTemplate = "<input type=\"hidden\" name=\"billing_cust_address\" value=\"$billing_cust_address$\" />\n";
                string billingCountryTemplate = "<input type=\"hidden\" name=\"billing_cust_country\" value=\"$billing_cust_country$\" />\n";
                string billingEmailTemplate = "<input type=\"hidden\" name=\"billing_cust_email\" value=\"$billing_cust_email$\" />\n";
                string billingTelTemplate = "<input type=\"hidden\" name=\"billing_cust_tel\" value=\"$billing_cust_tel$\" />\n";
                string billingStateTemplate = "<input type=\"hidden\" name=\"billing_cust_state\" value=\"$billing_cust_state$\" />\n";
                string billingCityTemplate = "<input type=\"hidden\" name=\"billing_cust_city\" value=\"$billing_cust_city$\" />\n";
                string billingZipTemplate = "<input type=\"hidden\" name=\"billing_zip_code\" value=\"$billing_zip_code$\" />\n";
                billingCustAddressTemplate = billingCustAddressTemplate.Replace("$billing_cust_address$", dtClientInfo.Rows[0]["Address"].ToString());
                billingCountryTemplate = billingCountryTemplate.Replace("$billing_cust_country$", dtClientInfo.Rows[0]["Country"].ToString());
                billingEmailTemplate = billingEmailTemplate.Replace("$billing_cust_email$", dtClientInfo.Rows[0]["Email_ID"].ToString());
                billingTelTemplate = billingTelTemplate.Replace("$billing_cust_tel$", dtClientInfo.Rows[0]["Phone_no"].ToString());
                billingStateTemplate = billingStateTemplate.Replace("$billing_cust_state$", dtClientInfo.Rows[0]["State"].ToString());
                billingCityTemplate = billingCityTemplate.Replace("$billing_cust_city$", dtClientInfo.Rows[0]["City"].ToString());
                billingZipTemplate = billingZipTemplate.Replace("$billing_zip_code$", dtClientInfo.Rows[0]["ZipCode"].ToString());
                strAmount = dt.Rows[i]["INR"].ToString();
                amountTemplate = amountTemplate.Replace("$Amount$", dt.Rows[i]["INR"].ToString());
                orderTemplate = orderTemplate.Replace("$Order_Id$", dt.Rows[i]["ClientID"].ToString());
                billingNameTemplate = billingNameTemplate.Replace("$billing_cust_name$", dtClientInfo.Rows[0]["Name"].ToString());
                CCAvenueItems.Append(amountTemplate)
                    .Append(orderTemplate)
                    .Append(billingNameTemplate)
                    .Append(billingCustAddressTemplate)
                    .Append(billingCountryTemplate)
                    .Append(billingEmailTemplate)
                    .Append(billingTelTemplate)
                    .Append(billingStateTemplate)
                    .Append(billingCityTemplate)
                    .Append(billingZipTemplate)
                    .Append(deliveryNameTemplate)
                    .Append(deliveryCustAddressTemplate)
                    .Append(deliveryCountryTemplate)
              }
            return CCAvenueItems.ToString();
        }
    }
 
 
