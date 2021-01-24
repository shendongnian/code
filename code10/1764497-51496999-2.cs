        foreach (var option in options)
        {
            RadioButton rb = new RadioButton(Context);
            rb.SetButtonDrawable(null);
            rb.SetCompoundDrawablesWithIntrinsicBounds(null,null,null,ContextCompat.GetDrawable(Context, Android.Resource.Drawable.ButtonRadio));
            rb.Text = option.Text;
            rb.Gravity = GravityFlags.Center;
            radioGroup.AddView(rb);
        }
        // Weight für die RBs setzen
        for (int i = 0; i < radioGroup.ChildCount; i++)
        {
            var currentRb = radioGroup.GetChildAt(i);
            LinearLayout.LayoutParams rbParams = new LinearLayout.LayoutParams(0,
                ViewGroup.LayoutParams.WrapContent) {Weight = 1};
            currentRb.LayoutParameters = rbParams;
        }
