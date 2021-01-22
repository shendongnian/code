         var blocking = true;
         function pageUnloading() {
             var control = document.getElementById("Xaml1");
             control.content.Page.FinalSave();
             while (blocking)
                 alert('Saving User Information');
         }
         function allowClose() {
             blocking = false;
         }
    </script> 
<body onbeforeunload="pageUnloading();">
</body>
and
app.xaml.cs
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
