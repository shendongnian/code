    MimePartContentDescription text;
    MimePartContentDescription html;
    MimePartContentDescription package;
    
    text = new MimePartContentDescription(
    	new ContentType("text/plain"),
    	Encoding.UTF8.GetBytes(message_text) );
    
    html = new MimePartContentDescription(
    	new ContentType("text/html"), 
    	Encoding.UTF8.GetBytes(message_html) );
    
    package = new MimePartContentDescription(
    	new ContentType("multipart/alternative"), null
    );
    					
    package.Add(html);
    package.Add(text);
    
    // Call BeginSendMessage ... SendMessageCompleted is async callback.
    imFlow.BeginSendMessage(package.ContentType, package.GetBody, SendMessageCompleted, imFlow)
