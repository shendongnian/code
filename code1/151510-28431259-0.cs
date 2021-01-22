    public static CustomerDetails ToCustomerDetails(this Tuple<Website.Customer, List<Website.Address>> customerAndAddress)
        {
            var mainAddress = customerAndAddress.Item2 != null ? customerAndAddress.Item2.SingleOrDefault(o => o.Type == "Main") : null;
            var customerDetails = new CustomerDetails
            {
                FirstName = customerAndAddress.Item1.Name,
                LastName = customerAndAddress.Item1.Surname,
                Title = customerAndAddress.Item1.Title,
                Dob = customerAndAddress.Item1.Dob,
                EmailAddress = customerAndAddress.Item1.Email,
                Gender = customerAndAddress.Item1.Gender,
                PrimaryPhoneNo = string.Format("{0}", customerAndAddress.Item1.Phone)
            };
            if (mainAddress != null)
            {
                customerDetails.AddressLine1 =
                    !string.IsNullOrWhiteSpace(mainAddress.HouseName)
                        ? mainAddress.HouseName
                        : mainAddress.HouseNumber;
                customerDetails.AddressLine2 =
                    !string.IsNullOrWhiteSpace(mainAddress.Street)
                        ? mainAddress.Street
                        : null;
                customerDetails.AddressLine3 =
                    !string.IsNullOrWhiteSpace(mainAddress.Town) ? mainAddress.Town : null;
                customerDetails.AddressLine4 =
                    !string.IsNullOrWhiteSpace(mainAddress.County)
                        ? mainAddress.County
                        : null;
                customerDetails.PostCode = mainAddress.PostCode;
            }
    ...
            return customerDetails;
        }
