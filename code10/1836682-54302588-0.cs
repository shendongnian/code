       CheckBox selectAll = FindViewById<CheckBox>(Resource.Id.button1);
       selectAll.SetOnCheckedChangeListener(this);
       public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
         {
            adapter.SelectAll(isChecked);
         }
