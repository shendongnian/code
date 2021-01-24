     class DataAdapter : BaseAdapter<Data>
        {
            readonly Activity context;
            public DataAdapter(Activity newContext, List<Data> newData) : base()
            {
                context = newContext;
                DataList = newData;
            }
            public List<Data> DataList { get; set; }
            public override int Count
            {
                get
                {
                    return DataList.Count;
                }
            }
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View newView = convertView; // re-use an existing view, if one is available
                if (newView == null) // otherwise create a new one
                    newView = context.LayoutInflater.Inflate(Resource.Layout.DataListItem, null);
                newView.FindViewById<TextView>(Resource.Id.DataId).Text = DataList[position].Id;
                newView.FindViewById<TextView>(Resource.Id.DataValue).Text = DataList[position].Value;
                return newView;
            }
            public override long GetItemId(int position)
            {
                return position;
            }
            public override Data this[int index]
            {
                get
                {
                    return DataList[index];
                }
            }
        }
