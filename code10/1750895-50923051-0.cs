    if (chk1.Checked == true)
    {
        if ((chk2.Checked == true)) //chk1 and chk2 are checked
        {
             Toast.MakeText(this, "full rice & Extra Sauce", ToastLength.Short).Show();
        }
        else //only the chk1 is checked
        {
             Toast.MakeText(this, "Extra Rice", ToastLength.Short).Show();
        }
    }
