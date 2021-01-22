    void PrintString(string strHTMLText)
    {
        WebBrowser wbPrintMobiles = new WebBrowser() { DocumentText = string.Empty };
        wbPrintMobiles.Document.Write(strHTMLText);
        wbPrintMobiles.Document.Title = "Type The Header You Want Here";
        Microsoft.Win32.RegistryKey rgkySetting = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\PageSetup", true);
        rgkySetting.SetValue("footer", "Type THe Footer You Want Here");
        rgkySetting.Close();
        wbPrintMobiles.ShowPrintPreviewDialog();
        wbPrintMobiles.Dispose();
}
