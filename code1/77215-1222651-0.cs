    /// <summary>
    /// SiteMap datasources cannot have duplicate Urls with the default provider.
    /// This finds duplicate urls in your heirarchy and tricks the provider into treating
    /// them correctly
    /// </summary>
    private void modifyDuplicateUrls()
    {
    StringCollection urls = new StringCollection();
    string rowUrl = String.Empty;
    uint duplicateCounter = 0;
    string urlModifier = String.Empty;
    foreach (DataTable dt in this.DataSource.Tables)
    {
    foreach (DataRow dr in dt.Rows)
    {
    rowUrl = (string)dr["Url"];
    if (urls.Contains(rowUrl))
    {
    duplicateCounter++;
    if (rowUrl.Contains("?"))
    {
    urlModifier = "&instance=" + duplicateCounter.ToString();
    }
    else
    {
    urlModifier = "?instance=" + duplicateCounter.ToString();
    }
    dr["Url"] = rowUrl + urlModifier;
    }
    else
    {
    urls.Add(rowUrl);
    }
    }
    }
    }
    }
