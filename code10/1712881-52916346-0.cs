    I used a for loop to iterate over my listView ChildCount, assigned a var as the Tag of the GetChildAt as ImageAdapterViewHolder and then set my checkbox to false.
    
    class ImageAdapterViewHolder : Java.Lang.Object
        {
            public ImageView SavedImage { get; set; }
            public TextView Description { get; set; }
            public CheckBox SelectImage { get; set; }
    
        }
    
    for (int i = 0; i < listView.ChildCount; i++)
                    {
                        var row = listView.GetChildAt(i).Tag as ImageAdapterViewHolder;
                        row.SelectImage.Checked = false;
                    }
