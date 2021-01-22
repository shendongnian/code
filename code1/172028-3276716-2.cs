    public partial class App : Application
    {
         [ScriptableMember()]
         public void FinalSave()
         {
            srTL.TrueLinkClient proxy = new CSRM3.srTL.TrueLinkClient();
            proxy.DeleteAllUserActionsCompleted += (sender, e) =>
                {
                    HtmlPage.Window.CreateInstance("allowClose");
                };
            proxy.DeleteAllUserActionsAsync(ApplicationUser.UserName);
         }
    }
