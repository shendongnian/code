      namespace testing_code
    {
        public class CustomGridViewAdapter : BaseAdapter
        {
            private Context context;
            private List<string> gridViewString;
            private List<string> gridViewImage;
            public CustomGridViewAdapter(Context context, List<string> gridViewstr, List<string> gridViewImage)
            {
                this.context = context;
                gridViewString = gridViewstr;
                this.gridViewImage = gridViewImage;
            }
            public override int Count
            {
                get
                {
                    return gridViewString.Count;
                }
            }
    
            public override Java.Lang.Object GetItem(int position)
            {
                return null;
            }
    
            public override long GetItemId(int position)
            {
                return 0;
            }
    
            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                View view;
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                if (convertView == null)
                {
                    view = new View(context);
                    view = inflater.Inflate(Resource.Layout.gridview_layout, null);
                    TextView txtview = view.FindViewById<TextView>(Resource.Id.textViewGrid);
                    ImageView imgview = view.FindViewById<ImageView>(Resource.Id.imageViewGrid);
    
                    txtview.Text = gridViewString[position];
                    imgview.SetImageBitmap(GetImageBitmapFromUrl(gridViewImage[position]));
                }
                else
                {
                    view = (View)convertView;
                }
                return view;
            }
    
            private Android.Graphics.Bitmap GetImageBitmapFromUrl(string url)
            {
                Android.Graphics.Bitmap imageBitmap = null;
    
                using (var webClient = new System.Net.WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = Android.Graphics.BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                   }
                    
    
                }
    
                return imageBitmap;
            }
        }
    }
