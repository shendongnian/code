    string picString = "90001000";
    foreach (XmlNode customerRecord in customerList)
    {
        XmlNode customerPIC = customerRecord.SelectSingleNode("//pic:customerPIC", nsManager);
        //let's consider the picstring wasn't found by default, for each customerRecord.
        bool isPicStringFound = false;
        foreach (XmlNode picList in customerPIC)
        {
            XmlNode idNumber = picList.SelectSingleNode("//pic:idNumber", nsManager);
            string idNumberString = idNumberString.InnerText;
            if (idNumberString == picString)
                isPicStringFound = true; //we found it ! no need to delete
        }
        //no picString found ? delete !
        if (!isPicStringFound)
            customerRecord.RemoveAll();
        //at next loop, the flag will be reset
    }
