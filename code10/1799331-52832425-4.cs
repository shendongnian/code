    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        switch (resultCode)
        {
            case Result.Ok:
                var position = data.getIntExtra("position", 0);
                var selectedString = reversedStringsMain[position];
                // fill in input field in MainActivity
                break;
        }
    }
