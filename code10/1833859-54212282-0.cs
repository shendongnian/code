    namespace CheckBoxDemo
    {
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TableLayout tl_view;
        CheckBox cb;
        TextView tv_view1;
        TextView tv_view2;
        TextView tv_view3;
        TextView tv_view4;
        TableRow tb;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
             tl_view = FindViewById<TableLayout>(Resource.Id.tl_view);
            int count = 1;
            Button bt_add = FindViewById<Button>(Resource.Id.bt_add);
            bt_add.Click += (e, o) => {
                addRole(ref count);
            };
        }
        public void addRole( ref int count)
        {
             cb = new CheckBox(this);
             tv_view1 = new TextView(this);
            if (count < 10)
            {
                tv_view1.Text = "0"+count;
                
            }
            else
            {
                tv_view1.Text = "" + count;
            }
            count++;
            tv_view2 = new TextView(this);
            tv_view2.Text = "test";
            tv_view3 = new TextView(this);
            tv_view3.Text = "test";
            tv_view4 = new TextView(this);
            tv_view4.Text = "1";
            tb = new TableRow(this);
            tb.AddView(cb);
            tb.AddView(tv_view1);
            tb.AddView(tv_view2);
            tb.AddView(tv_view3);
            tb.AddView(tv_view4);
            tl_view.AddView(tb);
        }
    }
    }
