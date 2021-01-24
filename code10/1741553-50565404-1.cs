    using Android.Content;
    using Android.Util;
    using App1.Droid;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    [assembly: ExportRenderer(typeof(App1.MyContentView), typeof(MyContentViewRender))]
    namespace App1.Droid
    {
        public class MyContentViewRender : ViewRenderer
        {
            
            public MyContentViewRender(Context context) : base(context)
            {
            }
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
            {
                base.OnElementChanged(e);
    
    
    
    
                this.TranslationX = (float)e.NewElement.TranslationX;
                this.TranslationY= (float)e.NewElement.TranslationY;
                Log.Error("Android========", "TranslationX=="+ TranslationX+ "--------TranslationY"+ TranslationY); 
                
            }
    
            protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
            {
                base.OnSizeChanged(w, h, oldw, oldh);
            }
        }
    }
