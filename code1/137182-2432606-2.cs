	public class GroovyDocument
	{
		public string GroovyID
		{
			get;
			set;
		}
	}
	public class AssetDocument
	{
		public int AssetID
		{
			get;
			set;
		}
	}
...
			List<AssetDocument> docs = new List<AssetDocument> ();
			docs.Add ( new AssetDocument () { AssetID = 3 } );
			docs.Add ( new AssetDocument () { AssetID = 8 } );
			docs.Add ( new AssetDocument () { AssetID = 10 } );
			MessageBox.Show ( docs.ToCSVList () );
			List<GroovyDocument> rocs = new List<GroovyDocument> ();
			rocs.Add ( new GroovyDocument () { GroovyID = "yay" } );
			rocs.Add ( new GroovyDocument () { GroovyID = "boo" } );
			rocs.Add ( new GroovyDocument () { GroovyID = "hurrah" } );
			MessageBox.Show ( rocs.ToCSVList () );
