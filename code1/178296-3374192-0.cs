    public void SearchForWatiNOnGoogle()
    {
        using (var browser = new Firefox("http://www.google.com"))
        {
            browser.TextField(Find.ByName("q")).TypeText("WatiN");
            browser.Button(Find.ByName("btnG")).Click();
            browser.Close();
         }
      }
