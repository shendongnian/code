    void PrintString(string strHTMLText)
    {
        WebBrowser wbPrintString = new WebBrowser() { DocumentText = string.Empty };
        wbPrintString.Document.Write(strHTMLText);
        wbPrintString.Document.Title = "Type The Header You Want Here";
        Microsoft.Win32.RegistryKey rgkySetting = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Internet Explorer\\PageSetup", true);
        rgkySetting.SetValue("footer", "Type THe Footer You Want Here");
        rgkySetting.Close();
        wbPrintString.Parent = this;
        wbPrintString.ShowPrintPreviewDialog();
        wbPrintString.Dispose();
}
