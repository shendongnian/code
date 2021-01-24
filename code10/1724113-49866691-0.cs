    // declare it here
    AutoCompleteTextView mautoCompleteTextView;
    // then instantiate it within the method
    public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
           ... // code omitted
           mautoCompleteTextView = view.FindViewById<AutoCompleteTextView>(Resource.Id.autoCompleteTextView1);
           ... // code omitted
        }
