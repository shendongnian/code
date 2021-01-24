    private ChatVM chatVM = new ChatVM();
    Public ChatVM ChatVMProperty // We need a property to bind
    {
        get { return chatVM; }
        set { chatVM = value; 
              /* Call Notify Property Changed if 
               you are assigning after constructor 
               getting called */ 
            }
    }
