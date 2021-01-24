    assembly: Dependency(typeof(DocumentView))]
    namespace MyApp.Droid.Services
    {
	public class DocumentView: IDocumentView
	{
		void IDocumentView.DocumentView(string filepath, string title)
		{
			try
			{
				File file = new File(filepath);
				String mime = FileTypes.GetMimeTypeByExtension(MimeTypeMap.GetFileExtensionFromUrl(filepath));
				File extFile = new File (Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments), file.Name);
				File extDir = extFile.ParentFile;
				// Copy file to external storage to allow other apps to access ist
				if (System.IO.File.Exists(extFile.AbsolutePath))
					System.IO.File.Delete(extFile.AbsolutePath);
				System.IO.File.Copy(file.AbsolutePath, extFile.AbsolutePath);
				file.AbsolutePath, extFile.AbsolutePath);
				// if copying was successful, start Intent for opening this file
				if (System.IO.File.Exists(extFile.AbsolutePath))
				{
					Intent intent = new Intent();
					intent.SetAction(Android.Content.Intent.ActionView);
					intent.SetDataAndType(Android.Net.Uri.FromFile(extFile), mime);
					MainApplication.FormsContext.StartActivityForResult(intent, 10);
				}
			}
			catch (ActivityNotFoundException anfe)
			{
				// android could not find a suitable app for this file
				var alert = new AlertDialog.Builder(MainApplication.FormsContext);
				alert.SetTitle("Error");
				alert.SetMessage("No suitable app found to open this file");
				alert.SetCancelable(false);
				alert.SetPositiveButton("Okay", (object sender, DialogClickEventArgs e) => ((AlertDialog)sender).Hide());
				alert.Show();
			}
			catch (Exception ex)
			{
				// another exception
				var alert = new AlertDialog.Builder(MainApplication.FormsContext);
				alert.SetTitle("Error");
				alert.SetMessage("Error when opening document");
				alert.SetCancelable(false);
				alert.SetPositiveButton("Okay", (object sender, DialogClickEventArgs e) => ((AlertDialog)sender).Hide());
				alert.Show();
			}
		}
	}
    }
