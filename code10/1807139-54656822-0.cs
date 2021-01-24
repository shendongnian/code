    var license = License.New()
        .WithUniqueIdentifier(Guid.NewGuid())
        //Look here
        .WithAdditionalAttributes(new Dictionary<string, string>
        {
            {"CompanyName", companyName }
        })
        .As(LicenseType.Trial)
        .ExpiresAt(DateTime.Now.AddDays(30))
        .WithMaximumUtilization(numberOfUsers)
        .LicensedTo(licensedTo, contactEmail)
        .CreateAndSignWithPrivateKey(privateKey, passPhrase);
