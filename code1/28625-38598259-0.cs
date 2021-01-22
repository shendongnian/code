    var licenseKey = "GEBNC-WZZJD-VJIHG-GCMVD";
    var RSAPubKey = "{enter the RSA Public key here}";
    var auth = "{access token with permission to access the activate method}";
    var result = Key.Activate(token: auth, parameters: new ActivateModel()
    {
        Key = licenseKey,
        ProductId = 3349,
        Sign = true,
        MachineCode = Helpers.GetMachineCode()
    });
    if (result == null || result.Result == ResultType.Error ||
        !result.LicenseKey.HasValidSignature(RSAPubKey).IsValid())
    {
        // an error occurred or the key is invalid or it cannot be activated
        // (eg. the limit of activated devices was achieved)
        Console.WriteLine("The license does not work.");
    }
    else
    {
        // everything went fine if we are here!
        Console.WriteLine("The license is valid!");
    }
    Console.ReadLine();
