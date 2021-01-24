    [Activity(Label = "CameraGallery", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    	{
    		public static int OPENCAMERACODE = 102;
    		//inside OnCreate after LoadApplication(new App()); add these lines
    		 protected override void OnCreate(Bundle bundle)
            {
    			TabLayoutResource = Resource.Layout.Tabbar;
                ToolbarResource = Resource.Layout.Toolbar;
                UserDialogs.Init(this);
                base.OnCreate(bundle);
    
                global::Xamarin.Forms.Forms.Init(this, bundle);
    
                FlowListView.Init();
                CachedImageRenderer.Init(false);
                LoadApplication(new App());
                MainPage.Instance.ShouldTakePicture += () =>
                {
                    ICursor cursor = loadCursor();
                    image_count_before = cursor.Count;
                    cursor.Close();
                    Intent intent = new Intent(MediaStore.IntentActionStillImageCamera);
                    IList<ResolveInfo> activities = PackageManager.QueryIntentActivities(intent, 0);
                    if(activities.Count >0)
                        StartActivityForResult(Intent.CreateChooser(intent, "Camera Capture"), OPENCAMERACODE);
                };
    		}
    		public ICursor loadCursor()
            {
                string[] columns = new string[] { MediaStore.Images.ImageColumns.Data, MediaStore.Images.ImageColumns.Id };
                string orderBy = MediaStore.Images.ImageColumns.DateAdded;
                return ContentResolver.Query(MediaStore.Images.Media.ExternalContentUri, columns, null, null, orderBy);
            }
            private void exitingCamera()
            {
                ICursor cursor = loadCursor();
                string[] paths = getImagePaths(cursor, image_count_before);
                MainPage.Instance.ShowImage(paths);// this parameter pass to MainPage.xaml.cs
                cursor.Close();
            }
            public string[] getImagePaths(ICursor cursor, int startPosition)
            {
                int size = cursor.Count - startPosition;
                if (size <= 0) return null;
                string[] paths = new string[size];
    
                int dataColumnIndex = cursor.GetColumnIndex(MediaStore.Images.ImageColumns.Data);
                for (int i = startPosition; i < cursor.Count; i++)
                {
                    cursor.MoveToPosition(i);
    
                    paths[i - startPosition] = cursor.GetString(dataColumnIndex);
                }
                return paths;
            }
    		//inside OnActivityResult method do this
            protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
            {
                base.OnActivityResult(requestCode, resultCode, data);
                switch (requestCode)
                {
                    case 102:
                            exitingCamera();
                        break;
                }
            }
    	}	
