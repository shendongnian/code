        Spinner _spinner1,_spinner2;
        _spinner=FindViewById<Spinner>(Resource.Layout._spinner1);
        _spinner.FindViewById<Spinner>(Resource.Layout._spinner2);
        _spinner1.ItemSelected += ItemSelected_Spinner1;
        _spinner2.ItemSelected += ItemSelected_Spinner2;
