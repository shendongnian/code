    /// <summary>
    /// Loads credential from a string containing JSON credential data.
    /// <para>
    /// The string can contain a Service Account key file in JSON format from the Google Developers
    /// Console or a stored user credential using the format supported by the Cloud SDK.
    /// </para>
    /// </summary>
    public static GoogleCredential FromJson(string json) => defaultCredentialProvider.CreateDefaultCredentialFromJson(json);
