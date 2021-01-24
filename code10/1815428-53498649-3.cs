         protected override void OnResume()
         {
            base.OnResume();
             _activity.RunOnUiThread(DoATask);
         }
