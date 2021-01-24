    if (chk1.Checked  && chk2.Checked && chk3.Checked)
    {
        Toast.MakeText(this, "full rice | Extra Sauce | Extra Rice", ToastLength.Short).Show();
    }
    else if (chk1.Checked && chk2.Checked )
    {
        Toast.MakeText(this, "full rice & Extra Sauce", ToastLength.Short).Show();
    }
    else if (chk1.Checked  && chk3.Checked )
    {
        Toast.MakeText(this, "full rice & Extra Rice", ToastLength.Short).Show();
    }
    else if (chk2.Checked  && chk3.Checked)
    {
        Toast.MakeText(this, "Extra Sauce & Extra Rice", ToastLength.Short).Show();
    }
    else if (chk1.Checked)
    {
        Toast.MakeText(this, "Extra Rice", ToastLength.Short).Show();
    }
