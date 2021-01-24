      private Dictionary<int, bool> checkBoxStatus = new Dictionary<int, bool>();
      public MyAdapter(int[] value)//in your constructor, it will be instantiated
            {
                item = value;
                for (int i = 0; i < item.Length; i++)
                {                
                    checkBoxStatus.Add(i,false);
                }
            }
       public void SelectAll(bool isChecked)
            {
              for (int i = 0; i < item.Length; i++)
                {
                    checkBoxStatus[i]= isChecked;
                }
              NotifyDataSetChanged();
            }
      public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var item = items[position];
                View view = convertView;
                view = context.LayoutInflater.Inflate(Resource.Layout.StockTakeUploadAdapter, null);
                view.DuplicateParentStateEnabled = true;
                createdview.Add(view);
                CheckBox chkBoxFileName = view.FindViewById<CheckBox>(Resource.Id.chkBoxFileName);
                chkBoxFileName .Checked = checkBoxStatus[position];
                chkBoxFileName.Tag = position;
                chkBoxFileName.SetOnCheckedChangeListener(this);
                view.FindViewById<TextView>(Resource.Id.lblFileName).Text = item.ST_filename.ToString();
                view.FindViewById<TextView>(Resource.Id.lblFileStatus).Text = item.ST_UploadStatus.ToString();
                if (!view.HasOnClickListeners)
                   view.Click += View_LongClick;
                   view.RefreshDrawableState();
                return view;
            }
      public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
            {
                checkBoxStatus[(int) buttonView.Tag]= isChecked;
                NotifyDataSetChanged();
                
            }
