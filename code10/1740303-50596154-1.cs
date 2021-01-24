    protected override void OnCreate(Bundle bundle) {
        base.OnCreate(bundle);
        creating += onCreateCore; //subscribe to event
        creating(this, EventArgs.Empty); //raise event
    }
    private event EventHandler creating = delegate { };
    private async void onCreateCore(object sender, EventArgs args) {
        creating -= onCreateCore; //unsubscribe to event
        var url = Intent.Data.ToString();
        var split = url.Split(new[] { "ombi://", "_" }, StringSplitOptions.RemoveEmptyEntries);
        if (split.Length > 1) {
            var dbLocation = new FileHelper().GetLocalFilePath("ombi.db3");
            var repo = new Repository<OmbiMobile.Models.Entities.Settings>(dbLocation);
            var settings = await repo.Get();
            foreach (var s in settings) {
                var i = await repo.Delete(s);
            }
            repo.Save(new Settings {
                AccessToken = split[1],
                OmbiUrl = split[0]
            });
        }
    
        Intent startup = new Intent(this, typeof(MainActivity));
        StartActivity(startup);
        Finish();
    }
