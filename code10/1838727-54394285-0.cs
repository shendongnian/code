using (var client = new WebClient())
{
    client.Encoding = System.Text.Encoding.UTF8;
    var text = client.DownloadString("http://shchakim.iscool.co.il/default.aspx");
    // The response from the server doesn't contains the word ביטול, therefore, for demo purposes I changed it for שוחרות which is present in the response.
    if (text.Contains("שוחרות"))
    {
        MessageBox.Show("idk");
    }
}
Here you can find more information about the WebClient.Encoding property:
https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient.encoding?view=netframework-4.7.2
Hope this helps.
