public string TranslateText(string input, string languagePair)
{
    string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
    WebClient webClient = new WebClient();
    webClient.Encoding = System.Text.Encoding.UTF8;
    string result = webClient.DownloadString(url);
    result = result.Substring(result.IndexOf(`"<span title=`\"") + "`<span title=`\"".Length);
    result = result.Substring(result.IndexOf(">") + 1);
    result = result.Substring(0, result.IndexOf("`</span`>"));
    return result.Trim();
}
</pre>
