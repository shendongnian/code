	public void ReplyCommandClick(string id, object msg)
	{
		MessageObject message = (MessageObject) msg;
		message.ShowReplyField = message.ShowReplyField ? false : true;
		//var viewcell = (MessageObject)((Label)msg).BindingContext;
		//viewcell. // There were no options for the entry
        var reply = msg.Reply;
		SendReply(id, msg, reply);
	} 
