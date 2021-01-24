    class YourAdapter : BaseAdapter,CompoundButton.IOnCheckedChangeListener
        {
            private Dictionary<int, bool> checkDictionary = new Dictionary<int, bool>();
            int[] item;  //raplace your own data
            public MyAdapter(int[] value) //raplace your own data
            {
                item = value;
                for (int i = 0; i < item.Length; i++)
                {
                    checkDictionary.Add(i,false);
                }
            }
 
    public override View GetView(int position, View convertView, ViewGroup parent)
        {
           var item = items[position];
           View view = convertView;
        //if (view == null)
          {
            view = context.LayoutInflater.Inflate(Resource.Layout.StockTakeEditDetailList, null);
            view.DuplicateParentStateEnabled = true;
            createdview.Add(view);
            RadioButton lblradio = view.FindViewById<RadioButton>(Resource.Id.lblradio);
            lblradio.Tag = position;
            lblradio.Checked = checkDictionary[position];
            lblradio.SetOnCheckedChangeListener(this);
            view.FindViewById<TextView>(Resource.Id.txtLineNo).Text = item.FileRecord_ID.ToString();  //my field in adapter.
            view.FindViewById<TextView>(Resource.Id.txtbinloc).Text = item.ST_BinLoc.ToString();
            view.FindViewById<TextView>(Resource.Id.txtBarcodett).Text = item.ST_Barcode.ToString();
            view.FindViewById<TextView>(Resource.Id.txtQtytt).Text = item.ST_Qty.ToString();
            if (!view.HasOnClickListeners)
                view.Click += View_LongClick;
            view.RefreshDrawableState();
          }
            return view;
        }
    public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            for (int i = 0; i < checkDictionary.Count; i++)
             {
               if (i == (int) buttonView.Tag)
                {
                    checkDictionary[i] = true;
                }
               else
                {
                    checkDictionary[i] = false;
                }
             }
                NotifyDataSetChanged();
                          
          }
       }
