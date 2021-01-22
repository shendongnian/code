    //------------------------------------------------------------------------------
    //Name: SendMessageToClient
    //Abstract: Send a message to the client side.
    //------------------------------------------------------------------------------
    protected void SendMessageToClient(string strMessage)
    {
	string strMessageToClient = "";
	//Allow single quotes on client-side in JavaScript
	strMessage = strMessage.Replace("'", "\\'");
	strMessageToClient = "<script type=\"text/javascript\" language=\"javascript\">alert( '" + strMessage + "' );</script>";
	this.ClientScript.RegisterStartupScript(this.GetType(), "ErrorMessage", strMessageToClient);
    }
