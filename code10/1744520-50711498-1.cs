        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.my_layout, container, false);
            var ll = view.FindViewById<LinearLayout>(Resource.Id.ll);
            var bt = view.FindViewById(Resource.Id.addbtn);
            bt.Click+= delegate
            {
                Fragment2 fragment2 = new Fragment2();
                FragmentTransaction ft = FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment2);
                ft.Commit();
                ll.Visibility = ViewStates.Gone;
            };
            return view;
        }
