    public override License GetLicense(LicenseContext context,
                                       Type type,
                                       object instance,
                                       bool allowExceptions)
        if (context.UsageMode == LicenseUsageMode.Designtime) {
            // Creating a special DesigntimeLicense will able you to design your
            // control without breaking Visual Studio in the process
            return new DesigntimeLicense();
        }
        byte[] existingSerialKey = getExistingSerial();
        // Algorithm can be SHA1CryptoServiceProvider for instance
        byte[] data = HashAlgorithm.Create().ComputeHash(
            username,
            dateRequested,
            validUntilDate,
            // any other data you would like to validate
        );
        // todo: also check if licensing period is over here. ;-)
        for (int l = 0; l < existingSerialKey.Length; ++l) {
            if (existingSerialKey[i] != data[i]) {
                if (allowExceptions){
                    throw new LicenseException(type, instance, "License is invalid");
                }
                return null;
            }
        }
        // RuntimeLicense can be anything inheriting from License
        return new RuntimeLicense();
    }
