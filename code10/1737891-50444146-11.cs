    private void Ms_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
    {
        var sm = sender as Switch;
        Log.Error("Ms_CheckedChange", (int)sm.Tag+"");
        if (e.IsChecked&&!mitems[(int)sm.Tag].isCheck)
        {
            mitems[(int)sm.Tag].isCheck = true;
            this.NotifyDataSetChanged();
        }
        else if(!e.IsChecked&& mitems[(int)sm.Tag].isCheck)
        {
            mitems[(int)sm.Tag].isCheck = false;
            this.NotifyDataSetChanged();
        }
       
    }
