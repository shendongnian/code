    protected override void OnSelectedIndexChanged(EventArgs e)
            {                       
                    CancelEventArgs cArgs = new CancelEventArgs();
                    //Next line!!
                    OnSelectedIndexChanged(cArgs);
    
                    if(!cArgs.Cancel)
                    {
                            base.OnSelectedIndexChanged(e);
                    }
            }
