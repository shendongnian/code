    private void Handler_Button1Tap(object s, EventArgs e)
    {
        ExpandAccordion(s);
    }
    
    private void Handler_Button2Tap(object s, EventArgs e)
    {
        ExpandAccordion(s);
    }
    
    private void ExpandAccordion(object sender)
    {
        // Implement whatever method is used to expand the accordion button.
        // Code taken from https://www.codeproject.com/Articles/1088093/Simple-Accordion-User-Control-in-Xamarin-Forms
        foreach (var vChildItem in mMainLayout.Children) 
        {
            if (vChildItem.GetType() == typeof(ContentView)) 
            {
                vChildItem.IsVisible = false;
            }
            
            if (vChildItem.GetType () == typeof(AccordionButton)) 
            {
                var vButton = (AccordionButton)vChildItem;
                vButton.Expand = false;
            }
        }
        
        var vSenderButton = (AccordionButton)sender;
        
        // TODO
        // Check which button has been tapped here!! 
        
        if (vSenderButton.Expand) 
        {
            vSenderButton.Expand = false;
        }
        else vSenderButton.Expand = true;
        vSenderButton.AssosiatedContent.IsVisible = vSenderButton.Expand;
    }
