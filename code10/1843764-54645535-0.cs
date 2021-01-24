      protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            client = new FireSharp.FirebaseClient(config);
            txtQuestion = FindViewById<TextView>(Resource.Id.textQuestion);
            
            //g variable is just for the test
            test();
        }
        public async void test()
        {
            var g = "test1";
            FirebaseResponse response = await client.GetAsync("question/" + g);
            Data obj = response.ResultAs<Data>();
            txtQuestion.Text = obj.question;
        }
