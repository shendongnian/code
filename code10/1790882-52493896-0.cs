    public Static void SomeFunc(){
     
                    var label = new HTMLLabelElement();
                    label.TextContent = txtbox.Value;
                    label.Style.FontSize = "40px";
     label.AddEventListener(EventType.Click,ClickEvent );
      
    }
    
        public static void ClickEvent (Event e)
                {
                    var x = (HTMLElement)e.Target;
                   x.SetAttribute("value", "HelloWorld");
                }
