    var sas = container.GetSharedAccessSignature(new SharedAccessBlobPolicy
    {
       Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List
       SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddYears(5)
    });
