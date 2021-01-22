    using (var client = new PayPalAPIInterfaceClient())
    {
        var credentials = new CustomSecurityHeaderType
        {
            Credentials = new UserIdPasswordType
            {
                Username = "username",
                Password = "password"
            }
        };
        var request = new AddressVerifyReq
        {
            AddressVerifyRequest = new AddressVerifyRequestType
            {
                Street = "some street",
                Zip = "12345"
            }
        };
        var response = client.AddressVerify(ref credentials, request);
    }
