            CustomValidator cv = (CustomValidator)sender;
            if (cv != null && cv.ID != null)
            {
                string cvID = cv.ID.ToString();
                switch (cvID)
                {
                    case "CustValidEMIActionOffDate":
                        reqEMIActionOffDate.Visible = false;
                        break;
                    case "CustValidSignatureDateTextBox":
                        reqSigDate.Visible = false;
                        break;
                    case "CustValidPrimaryDateTextBox":
                        reqPrimaryDate.Visible = false;
                        break;
                    case "CustValidAltDateTextBox":
                        reqAltDate.Visible = false;
                        break;
                }
            }
