     public override void OnViewCreated(View view, Bundle savedInstanceState)
    {
        base.OnViewCreated(view, savedInstanceState);
        imageView =view.FindViewById<ImageView>(Resource.Id.Iv_ScanImg);
        var btnCamera =view. FindViewById<Button>(Resource.Id.btnCamera);
        btnCamera.Click += BtnCamera_Click;
    }
