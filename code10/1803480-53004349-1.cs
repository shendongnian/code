        public class ActivityB : Activity
    {
        EditText edittext2;
        Button button2;
        string valueFromA;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout2);
            valueFromA = Intent.Extras.GetString("PassParameters");
            edittext2 = FindViewById<EditText>(Resource.Id.editText2);
            edittext2.Text = valueFromA;
            button2 = FindViewById<Button>(Resource.Id.button2);
            button2.Click += delegate {
                //Call Your Method When User Clicks The Button
                Intent updatevalue = new Intent(this, typeof(ActivityC));
                updatevalue.PutExtra("PassParameters", edittext2.Text);
                StartActivityForResult(updatevalue, 0);
            };
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                string dataFromC = data.GetStringExtra("PassParameters");
                edittext2.Text = dataFromC;
            }
        }
    }
