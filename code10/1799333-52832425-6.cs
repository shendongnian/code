    ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
    {
        Intent intent = new Intent(this, typeof(HistoryActivity)); 
        intent.PutExtra("position", args.Position); 
        SetResult(Result.Ok, intent); 
        Finish();
    } 
