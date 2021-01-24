    public ProgressDialog ProgressBar(Context context, string position)
    {
    
    	var pbr = new ProgressDialog(context);
    	pbr.SetCancelable(false);
    	pbr.Indeterminate = true;
    	pbr.SetProgressStyle(ProgressDialogStyle.Spinner);
    	switch (position.ToLower())
    	{
    		case "c":
    			pbr.Window.SetGravity(GravityFlags.Center);
    			break;
    		case "b":
    			pbr.Window.SetGravity(GravityFlags.Bottom);
    			break;
    
    	}
    	pbr.SetMessage("please wait..");
    	return pbr;
    }
