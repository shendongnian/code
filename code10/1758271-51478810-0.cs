    using System;
    using Xamarin.Forms;
    using Plugin.FilePicker;
    using Plugin.FilePicker.Abstractions;
    using Android.Support.V4.Content;
    using Android;
    using Android.Support.V4.App;
    using Android.App;
    using Android.Content.PM;
    using Android.Runtime;
    namespace FilesTest
    {
    public partial class MainPage : ContentPage, ActivityCompat.IOnRequestPermissionsResultCallback
	{
		public IntPtr Handle => default(IntPtr) ;
		public MainPage(){InitializeComponent();}
		async void Pic()//the function that triggers the file picker
        {
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null) {
                    return; // user canceled file picking
                }
                string fileName = fileData.FileName;
                string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray);
				Console.WriteLine("File name chosen: " + fileName);
				Console.WriteLine("File data: " + contents);
            }
            catch (Exception ex)
            {
				Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
        }
        private void PickFileButton_Clicked(object sender, EventArgs e)//in the xaml there is a button that triggers this function
        {
			var thisActivity = Forms.Context as Activity;
			if(ContextCompat.CheckSelfPermission(thisActivity, Manifest.Permission.ReadExternalStorage) != Permission.Granted)
			{// Permission is not granted
				ActivityCompat.RequestPermissions(thisActivity, new String[] {Manifest.Permission.ReadExternalStorage }, 1);//1 is just the code to retrive this permission
			} else
			{//if permission is already granted
				Pic();
			}
        }
		public void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) // this function is called after the permission box is shown and the user picked whether to grant or deny the permission
		{
			if(requestCode == 1)
			{
				if(grantResults.Length > 0 && grantResults[0] == Permission.Granted)
				{//permission has been granted by the user
					Pic();
				} else
				{//permission denied
				}
			}
		}
		public void Dispose(){}
	}
    }
