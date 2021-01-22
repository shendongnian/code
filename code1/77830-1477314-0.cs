    private class myPSHost : PSHost
    {
       (Same as what the above link mentions)
    }
    private class myPSHostUI : PSHostUserInterface
    {
       private myPSHostRawUI rawui = new myPSHostRawUI();
    
       public override void Write // all variations
       public override PSHostRawUserInterface RawUI { get { return rawui; } }
       
    }
    private class myPSHostRawUI : PSHostRawUserInterface
    {
       public override ConsoleColor ForegroundColor
       public override ConsoleColor BackgroundColor
       public override Size BufferSize
    }
