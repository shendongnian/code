    public void Main()
    {
        // TODO: Add your code here
        WebClient wc = new WebClient();// { UseDefaultCredentials = true };
        wc.Headers.Add(HttpRequestHeader.Cookie, "NSC_JOmbbd3tb4=ffffffffc3a03f7e45525; User=eyJhbGciOiJSU");
        var DownloadPath = Dts.Variables["User::varDownloadPathNew"].Value.ToString();
        DateTime startDate = DateTime.Parse(Dts.Variables["User::StartDate"].Value.ToString());
        DateTime enddate = DateTime.Parse(Dts.Variables["User::EndDate"].Value.ToString());
        wc.Credentials = new NetworkCredential("UserName", "Password");
        wc.DownloadFile("https://Test123.co.uk/model/download?&startfilter=" + startDate.ToString("dd") + "%2F" + startDate.ToString("MM") + "%2F" + startDate.ToString("yyyy") + "&mnu_jobdateendfilter=" + enddate.ToString("dd") + "%2F" + enddate.ToString("MM") + "%2F" + enddate.ToString("yyyy") + "&%A6&maxrows=400&format=excel&filename=Test.xls", DownloadPath);
        Dts.TaskResult = (int)ScriptResults.Success;
    }
