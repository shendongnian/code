	public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	{
		switch (requestCode)
		{
			case 999:
				if (grantResults[0] == Permission.Granted)
				{
					// you have permission, you are allowed to read/write to external storage go do it...
				}
				break;
			default:
				break;
		}
	}
