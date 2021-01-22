    public class SearchPageWrapper {
      ...
      public void ClickAdvancedSearch() {
        _browser.Buttons("advSearch").Click();
      }
    
      public void EnterSearchPhrase(string phrase) {
        _browser.TextBox(Find.ByName("phrase")).TypeText(phrase);
      }
      ... etc ...
    }
