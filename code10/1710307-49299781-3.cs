    public class MyAdapter : PagerAdapter
    {
        List<int> ListImages;
        Context context;
        LayoutInflater LayoutInflater;
    
        public MyAdapter(List<int> ListImages, Context context)
        {
            this.ListImages = ListImages;
            this.context = context;
            LayoutInflater = LayoutInflater.From(context);
        }
    
        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            View view = LayoutInflater.Inflate(Resource.Layout.Item,container,false);
            ImageView imageView = view.FindViewById<ImageView>(Resource.Id.imageview);
            imageView.SetImageResource(ListImages[position]);
            container.AddView(view);
            return view;
    
        }
    
        public override int Count => ListImages.Count;
    
        public override bool IsViewFromObject(View view, Java.Lang.Object objectValue)
        {
            return view.Equals(objectValue);
        }
        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object objectValue)
        {
            container.RemoveView((View)objectValue);
        }
    }
