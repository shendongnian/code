    public class ActivityA : Activity
    {
        Button button1;
        EditText textBox1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout1);
            button1 = FindViewById<Button>(Resource.Id.button1);
            textBox1 = FindViewById<EditText>(Resource.Id.editText1);
                        
            button1.Click += delegate {
                //Call Your Method When User Clicks The Button
                Intent updatevalue = new Intent(this, typeof(ActivityB));
                updatevalue.PutExtra("PassParameters", textBox1.Text);
                StartActivity(updatevalue);
            };
        }
    }
