    using System;
    using System.Collections.Generic;
    using Android.App;
    using Android.Content;
    using Android.Views;
    using Android.Widget;
    using NovaAndroid.Model;
    namespace NovaAndroid.Adapters
    {
    [Activity(Label = "ContactListBaseAdapter")]
    public partial class ContactListBaseAdapter : BaseAdapter<the_SetSubjModel>
    {
        IList<the_SetSubjModel> contactListArrayList;
        private LayoutInflater mInflater;
        private Context activity;
        the_SetSubjModel model = new the_SetSubjModel();
        Dictionary<int, the_SetSubjModel> items;
        private Context mContext;
        private int mRowLayout;
      
        public ContactListBaseAdapter(Context context, IList<the_SetSubjModel> results, 
    int rowLayout) 
        {
            this.activity = context;
            this.items = items;
            context = context;
            mContext = context;
            mRowLayout = rowLayout;
            contactListArrayList = results;
            mInflater = 
     (LayoutInflater)activity.GetSystemService(Context.LayoutInflaterService);
        }
        public override int Count
        {
            get { return contactListArrayList.Count; }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
       
        public override the_SetSubjModel this[int position]
        {
            get { return items[position]; }
        }
       
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
      
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
           
            View view = convertView;
            if(view==null)
            {
               // view = LayoutInflater.From(mContext).Inflate(mRowLayout, parent, 
      false);
                //view = Layou   // view = 
      context.tInflater.From(mContext).Inflate(mRowLayout, parent, false);
                //view = 
      LayoutInflater.From(mContext).Inflate(Resource.Layout.list_row_contact_list, null);
            }
            //ImageView btnDelete;
            //ContactsViewHolder holder = null;
          
                view = mInflater.Inflate(Resource.Layout.list_row_contact_list, null);
                //holder = new ContactsViewHolder();
                //// Show item in listView
                //holder.txtacSubject = view.FindViewById<TextView> 
     (Resource.Id.lr_fullName);
                //holder.txtacAddress = view.FindViewById<TextView> 
     (Resource.Id.lr_address);
                //holder.txtEmail = view.FindViewById<TextView>(Resource.Id.lr_email);
                //holder.txtPib = view.FindViewById<TextView>(Resource.Id.lr_pib);
                //view.Tag = holder;
              
          
            TextView txtacSubject = view.FindViewById<TextView>(Resource.Id.lr_fullName);
            txtacSubject.Text = contactListArrayList[position].acSubject;
            TextView txtacAddress = view.FindViewById<TextView>(Resource.Id.lr_address);
            txtacAddress.Text = contactListArrayList[position].acAddress;
            TextView txtEmail = view.FindViewById<TextView>(Resource.Id.lr_email);
            txtEmail.Text = contactListArrayList[position].acPost;
            TextView txtPib = view.FindViewById<TextView>(Resource.Id.lr_pib);
            txtPib.Text = contactListArrayList[position].acCode;
            if (position % 2 == 0)
            {
                view.SetBackgroundResource(Resource.Drawable.list_selector);
            }
            else
            {
                view.SetBackgroundResource(Resource.Drawable.list_selector_alternate);
            }
            view.Click += delegate
              {
                  Toast.MakeText(mContext, contactListArrayList[position].acSubject, 
			ToastLength.Short).Show();
              };
            view.LongClick += delegate
              {
                  
              };
         
            return view;
          
        }
       
        public IList<the_SetSubjModel> GetAllData()
        {
            return contactListArrayList;
        }
        public class ContactsViewHolder : Java.Lang.Object
        {
            public TextView txtacSubject { get; set; }
            public TextView txtacAddress { get; set; }
            public TextView txtEmail { get; set; }
            public TextView txtPib { get; set; }            
            public TextView txtacName2 { get; set; }
            public TextView txtacPhone { get; set; }
            public TextView txtacRegNo { get; set; }
            public TextView txtanRebate { get; set; }
        }
        class ContactListBaseAdapterViewHolder : Java.Lang.Object
        {
            //Your adapter views to re-use
            //public TextView Title { get; set; }
        }
    }
    }
