    using Android.App;
    using Android.OS;
    using Android.Support.V7.App;
    using Android.Runtime;
    using Android.Widget;
    using System;
    using Android.Views;
    
    namespace App46
    {
        [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
        public class MainActivity : Activity
        {
            string[] items;
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.activity_main);
                items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
                ArrayAdapter adapter = new ArrayAdapter<String>(this, Resource.Layout.list_item, items);
                ListView lv = FindViewById<ListView>(Resource.Id.listView1);
                lv.Adapter = adapter;
    
                lv.ItemLongClick += delegate (object sender, AdapterView.ItemLongClickEventArgs args)
                {
                    Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();
                };
            }
    
    
        }
    
    }
