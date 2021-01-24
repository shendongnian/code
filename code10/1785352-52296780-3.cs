    [assembly: Dependency(typeof(DocumentView))]
    namespace MyApp.iOS.Services
    {
	public class DocumentView: IDocumentView
	{
		void IDocumentView.DocumentView(string file, string title)
		{
			UIApplication.SharedApplication.InvokeOnMainThread(() =>
			{
				QLPreviewController previewController = new QLPreviewController();
				if (File.Exists(file))
				{
					previewController.DataSource = new PDFPreviewControllerDataSource(NSUrl.FromFilename(file), title);
					UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(previewController, true, null);
				}
			});
		}
    }
    public class PDFItem : QLPreviewItem
	{
		public PDFItem(string title, NSUrl uri)
		{
			this.Title = title;
			this.Url = uri;
		}
		public string Title { get; set; }
		public NSUrl Url { get; set; }
		public override NSUrl ItemUrl { get { return Url; } }
		public override string ItemTitle { get { return Title; } }
	}
	public class PDFPreviewControllerDataSource : QLPreviewControllerDataSource
	{
		PDFItem[] sources;
		public PDFPreviewControllerDataSource(NSUrl url, string filename)
		{
			sources = new PDFItem[1];
			sources[0] = new PDFItem(filename, url);
		}
		public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
		{
			int idx = int.Parse(index.ToString());
			if (idx < sources.Length)
				return sources.ElementAt(idx);
			return null;
		}
		public override nint PreviewItemCount(QLPreviewController controller)
		{
			return (nint)sources.Length;
		}
	}
    }
