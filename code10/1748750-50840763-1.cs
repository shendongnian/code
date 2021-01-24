    var editText = FindViewById<EditText> (Resource.Id.editText);
    editText.TextChanged += (object sender, Android.Text.TextChangedEventArgs et) => {
        //step 1 grab editText value
        String newString = et.Text.ToString(); 
        //step 2 replace unwanted characters (currently '.' & '-')
        newString = newString.Replace(".", "").Replace("-", "");
        //step 3 set the editText field to the updated string
        editText.Text = newString;
    };
