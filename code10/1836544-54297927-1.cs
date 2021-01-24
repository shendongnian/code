	protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
	{
		if (resultCode == Result.Ok && requestCode == 88)
		{
            // Do something with your photo...
			Log.Debug("SO", cacheName );
		}
    }
