     public class Meeting1Adapter: MvxRecyclerAdapter
    {
        private Activity activity;
        public IMvxAndroidBindingContext bindingCtxt;
        protected IMvxAndroidBindingContext BindingContext => bindingCtxt;
        public MeetingsMain meetingMain { get; set; }
        public Meeting1Adapter(IMvxAndroidBindingContext bindingContext, Activity activity, MeetingsMain meetingsMain)
        {
            this.bindingCtxt = bindingContext;
            this.activity = activity;
            this.meetingMain = meetingsMain;
        }
     ----
       public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            try
            {
                var itemBindingContext = new MvxAndroidBindingContext(parent.Context, this.BindingContext.LayoutInflaterHolder);
                var id = Resource.Layout.item_layout;
                View itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);
                return new MeetingsAdapterValueTypeViewHolder(itemView, itemBindingContext);
               // return new MeetingsAdapterValueTypeViewHolder(itemView);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in response ## " + e.Message);
            }
            return null;
        }
     ----
    }
  
