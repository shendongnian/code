    public class FruitAdapter : BaseAdapter
    {
        private readonly Activity context;
        private readonly List<Fruit> fruits;
        public FruitAdapter(Activity _context, List<Fruit> _fruits)
        {
            this.context = _context;
            this.fruits = _fruits;
        }
        public override int Count
        {
            get
            {
                return fruits.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return fruits[position].imageId;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            FruitHolder holder = null;
            View view = convertView;
            if (view == null)
            {
                holder = new FruitHolder();
                view = context.LayoutInflater.Inflate(Resource.Layout.fruit_item, parent, false);
                holder.FruittName = view.FindViewById<TextView>(Resource.Id.fruit_name);
                holder.FruitButton = view.FindViewById<ImageView>(Resource.Id.fruit_image);
                view.Tag = holder;
            }
            else
            {
                holder = (FruitHolder)view.Tag;
            }
            holder.FruittName.Text = fruits[position].Name;
            holder.FruitButton.SetImageResource(fruits[position].imageId);
            if (!holder.FruitButton.HasOnClickListeners)
            {
                holder.FruitButton.Click += (object sender, EventArgs e) =>
                {
                    fruits.RemoveAt(position);
                    NotifyDataSetChanged();
                };
            }
            //holder.FruitButton.Click += (object sender, EventArgs e) =>
            //{
            //    fruits.RemoveAt(position);
            //    NotifyDataSetChanged();
            //};
            return view;
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        private class FruitHolder : Java.Lang.Object
        {
            public TextView FruittName { get; set; }
            public ImageView FruitButton { get; set; }
        }
    }
    public class Fruit
    {
        public int imageId { get; set; }
        public string Name { get; set; }
        public Fruit(string name, int id)
        {
            imageId = id;
            Name = name;
        }
    }
