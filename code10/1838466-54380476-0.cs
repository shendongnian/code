	void IterateViews(ViewGroup vg)
	{
		for (int i = 0; i < vg.ChildCount; i++)
		{
			var view = vg.GetChildAt(i);
			if (view is ViewGroup)
			{
				IterateViews(view as ViewGroup);
			}
			Log.Debug("SO", $"{view.Id.ToString()} : {Resources.GetResourceEntryName(view.Id)}");
		}
	}
	var aViewGroup = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
	IterateViews(aViewGroup);
