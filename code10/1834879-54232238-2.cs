            foreach (var item in Enum.GetValues(typeof(CountryListEnum)))
            {
                CountryModel myModel = new CountryModel();
                myModel.CountryId = item.GetHashCode();
                var type = typeof(CountryListEnum);
                var memInfo = type.GetMember(item.ToString());
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)attributes[0]).Description;
                myModel.CountryName = description;
            }
