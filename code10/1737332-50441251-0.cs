    using Android.App;
    using Android.OS;
    using Android.Util;
    using Android.Views;
    
    namespace FragmentTest
    {
        public class Fragment1 : Fragment,View.IOnTouchListener
        {
            public override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Create your fragment here
            }
    
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                // Use this to return your custom view for this Fragment
                var view = inflater.Inflate(Resource.Layout.layout1, container, false);
                view.SetOnTouchListener(this);
                return view;
    
                
            }
    
            public bool OnTouch(View v, MotionEvent e)
            {
                if (e.Action == MotionEventActions.Move){
                    //do something 
                    Log.Error("lv","MOVE++++++++++++++++++");
                    }
    
                return true;
            }
        }
    }
