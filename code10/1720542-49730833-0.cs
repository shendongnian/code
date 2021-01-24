            public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null)
            {
                // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.Quotes, null);
            }
            view.FindViewById<TextView>(Resource.Id.Quotes).Text = item.s_Quotes;
            view.FindViewById<TextView>(Resource.Id.From).Text = item.s_From;
            view.FindViewById<TextView>(Resource.Id.Category).Text = item.Category;
            Button btnCopy = view.FindViewById<Button>(Resource.Id.btnCopy);
            btnCopy.Click += delegate
            {
                Toast.MakeText(this.context, items[position].s_From, ToastLength.Short).Show();
            };
            return view;
        }
