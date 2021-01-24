            string strsvresponse = "name:bob, age:22, city:Wolverhampton, state:West Midlands, UK, country: United Kingdom";
            string iKey = string.Empty;
            string iValue = string.Empty;
            int iMode = 0;
            Dictionary<string, string> dictusrdata = new Dictionary<string, string>();
            for (int i = 0; i < strsvresponse.Length; i++)
            {
                if (iMode == 0)
                {
                    if (strsvresponse[i] == ':')
                    {
                        iMode = 1;
                    } 
                    else if (strsvresponse[i] == ',')
                    {
                        iKey = string.Empty;
                        iValue = string.Empty;
                    }
                    else
                    {
                        iKey += strsvresponse[i];
                    }
                }
                else
                {
                    if (strsvresponse[i] == ',')
                    {
                        dictusrdata.Add(iKey.Trim(), iValue.Trim());
                        iKey = string.Empty;
                        iValue = string.Empty;
                        iMode = 0;
                    }
                    else
                    {
                        iValue += strsvresponse[i];
                    }
                }
            }
            //add last value
            if (!string.IsNullOrEmpty(iKey))
            {
                dictusrdata.Add(iKey.Trim(), iValue.Trim());
            }
