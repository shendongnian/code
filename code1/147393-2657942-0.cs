    using Microsoft.Security.Application;
    namespace RegisterClientScriptBlock
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                String alertScript;
                String inputWord;
                String encodedWord;
                encodedWord = AntiXss.JavaScriptEncode(inputWord);
                alertScript = "function alertShowMessage() {";
                if (checkIfWordHasBeenUsed(inputWord) == true)
                {
                    alertScript = alertScript + "alert('You have already used the message:" + encodedWord + "');}";
                }
                else
                {
                    alertScript = alertScript + "alert('You have not used the message:" + encodedWord + "');}";
                }
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alertShowMessage", alertScript, true);
            }
        }
    }
