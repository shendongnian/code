    public void InternalStartup()
    {          
    	EventManager.FormEvents.ContextChanged += new ContextChangedEventHandler(FormEvents_ContextChanged);
    	EventManager.XmlEvents["/my:DoanhNghieps/my:loaiHinhHoatDong"].Changed += new XmlChangedEventHandler(loaiHinhHoatDong_Changed);
    }  
    
    public void FormEvents_ContextChanged(object sender, ContextChangedEventArgs e)
    {           
    	if (canRedirect) 
    	{ 
    		canRedirect = false; 
    		ViewInfos.SwitchView("CN"); 
    	}
    }
    private bool canRedirect = false;
    public void loaiHinhHoatDong_Changed(object sender, XmlEventArgs e)
    {
    	// Write your code here to change the main data source.
    	canRedirect = true;            
    } 
