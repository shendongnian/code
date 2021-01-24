            foreach (var item in Enum.GetValues(typeof(CountryListEnum)))
            {
                CountryModel myModel = new CountryModel();
                myModel.CountryId = item.GetHashCode();
                myModel.CountryName = item.ToString();
            }
