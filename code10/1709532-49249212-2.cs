    public class MyGridViewAdapter : BaseAdapter
    {
        string[] _items;
        public MyGridViewAdapter(string[] items)
        {
            _items = items;
        }
        public override int Count => _items.Length;
        public override Java.Lang.Object GetItem(int position)
        {
            return _items[position];
        }
        public override long GetItemId(int position)
        {
            return 0;
        }
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
    }
