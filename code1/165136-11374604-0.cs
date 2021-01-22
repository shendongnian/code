    delegate void ActionExecutorOnUI(ref HtmlElement a, string b, string c);
    private void SetValueOnHtmlElementOnUIThread(this HtmlElement onElement, string propToChange, string valueGiven, WebBrowser linkToWebBrowser)
    		{
    			if (linkToWebBrowser.InvokeRequired)
    			{
    				ActionExecutorOnUI d = new ActionExecutorOnUI(SetValueOnHtmlElementOnUIThread);
    				linkToWebBrowser.Invoke(d, new object[] { });
    			}
    			else
    				SetValueOnHtmlElementOnUIThread(ref onElement, propToChange, valueGiven);
    			  
    		}
    
    private void SetValueOnHtmlElementOnUIThread(ref HtmlElement onElement, string propToChange, string valueGiven)
    		{
    			onElement.SetAttribute("value", "user"); 
    		}
