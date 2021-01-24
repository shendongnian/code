    for (; ; System.Threading.Thread.Sleep(20) )
    {
    	//Send spacebar would go here
    	p.Send(green);
    	System.Threading.Thread.Sleep(20);
    	p.Send(regular);
    	System.Threading.Thread.Sleep(20);
    	memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);
    	string str = "";
    	str = string.Format(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
    	@"\Screenshot.png");
    	memoryImage.Save(str);
    
    }
