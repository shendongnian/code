      var viewGroup = (ViewGroup)FindViewById<LinearLayout>(Resource.Id.MyLayout);
    
            for (int i = 0; i < viewGroup.ChildCount; i++)
            {
                var childView = viewGroup.GetChildAt(i);
    
                if (childView is TextView)
                {
                    //do what ever you have to do
                }
            }
