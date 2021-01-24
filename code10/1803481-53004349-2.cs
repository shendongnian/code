        public class ActivityC : Activity
    {
        EditText edittext3;
        Button button3;
        string valueFromB;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout3);
            valueFromB = Intent.Extras.GetString("PassParameters");
            edittext3 = FindViewById<EditText>(Resource.Id.editText3);
            edittext3.Text = valueFromB;
            button3 = FindViewById<Button>(Resource.Id.button3);
            button3.Click += delegate {
                Intent HRvalue = new Intent(this, typeof(ActivityB));
                HRvalue.PutExtra("PassParameters", edittext3.Text);
                SetResult(Result.Ok, HRvalue);
                Finish();
            };
        }
    }
