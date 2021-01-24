    private void Button_ClickA(object sender, System.EventArgs e)
    {      
        var videoIntent = new Intent(
            Intent.ActionPick);
        videoIntent.SetType("video/*");
        videoIntent.PutExtra(Intent.ExtraAllowMultiple, true);
        videoIntent.SetAction(Intent.ActionGetContent);
        ((Activity)this).StartActivityForResult(
            Intent.CreateChooser(videoIntent, "Select videos"), 0);
    }
    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
    {           
        if (data.ClipData != null)
        {
            for (var i = 0; i < data.ClipData.ItemCount; i++)
            {
                var video = data.ClipData.GetItemAt(i);
                Uri videouri = video.Uri;
                var path = videouri.Path;
            }
        }
        else
        {
            Uri videouri = data.Data;
            var path = videouri.Path;
        }
    }
