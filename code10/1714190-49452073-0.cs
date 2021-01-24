    class MyActivity extends Activity implements ProgressBarHandler{
        //other usual things in your activity
        
        protected override async void OnCreate(Bundle savedInstanceState){
            //here pass the activity instance to WebViewClientClass
            webView.SetWebViewClient(new WebViewClientClass(this)); 
        }
        public void hideProgress(){
            PB.Visibility = ViewState.Gone;
        }
    }
