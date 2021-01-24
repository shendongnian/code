    for (var i = 0; ; i++)   // <----- note 'i'
    {
        System.Threading.Thread.Sleep(20); // move sleep to here
    	//Send spacebar would go here
    	p.Send(green);
    	System.Threading.Thread.Sleep(20);
    	p.Send(regular);
    	System.Threading.Thread.Sleep(20);
    	memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);
    	string str = "";
    	str = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
    	                    $@"\Screenshot{i}.png");  // use 'i' here
    	memoryImage.Save(str);
    
    }
