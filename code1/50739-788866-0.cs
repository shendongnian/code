    [Test] 
    public void SearchForWatiNOnGoogle()
    {
     using (IE ie = new IE("http://www.google.com"))
     {
      ie.TextField(Find.ByName("q")).TypeText("WatiN");
      ie.Button(Find.ByName("btnG")).Click();
      
      Assert.IsTrue(ie.ContainsText("WatiN"));
     }
    }
