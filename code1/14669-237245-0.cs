    public void DoTheseThings()
    {
        SafelyDoEach( new Action[]{
            DoThis,
            NowDoThat,
            NowDoThis,
            MoreWork,
            AndImSpent
        })
    }
    
    public void SafelyDoEach( params Action[] actions )
    {
        try
        {
            foreach( var a in actions )
                a();
        }
        catch( Exception doThisException )
        {
            // blindly swallowing every exception like this is a terrible idea
            // you should really only be swallowing a specific MyAbortedException type
            return;
        }
    }
