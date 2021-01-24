    using System;
    using Android.Runtime;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;
    using neoFly_Montana.Droid;
    
    [assembly: ExportRenderer(typeof(Xamarin.Forms.Label), typeof(NeoFly_MontanaLabelRenderer))]
    namespace neoFly_Montana.Droid
    {
        public class NeoFly_MontanaLabelRenderer : Xamarin.Forms.Platform.Android.LabelRenderer
        {
            public NeoFly_MontanaLabelRenderer(Context context) : base(context)
            {
                
            }
        }
    }
