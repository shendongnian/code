using NoBounceiOS.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(ListView), typeof(NoBounceRenderer))]
namespace NoBounceiOS.iOS
{
	public class NoBounceRenderer : ListViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.AlwaysBounceVertical = false;
			}
		}
	}
}
