    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        View view=null;
        if (convertView != null)
        {
            view = convertView;
        }
        else
        {
            view = LayoutInflater.FromContext(parent.Context).Inflate(Resource.Layout.item1,null);
        }
        if (position == 0)
        {
            view.SetBackgroundColor(Android.Graphics.Color.Yellow);
        }
        else
        {
            view.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
        (view as TextView).Text = _items[position];
        return view;
    }
