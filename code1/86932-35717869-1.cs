        foreach (CountryModel item in CountryModel.GetCountryList())
            {
                if (item.CountryPhoneCode.Trim() != "974")
                {
                    countries.Add(new SelectListItem { Text = item.CountryName + " +(" + item.CountryPhoneCode + ")", Value = item.CountryPhoneCode });
                }
                else {
                    
                    countries.Add(new SelectListItem { Text = item.CountryName + " +(" + item.CountryPhoneCode + ")", Value = item.CountryPhoneCode,Selected=true });
                }
            }
 
