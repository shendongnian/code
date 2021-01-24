	class SimpleGenericModel : INomAndId
	{
		public int Id { get; set; }
		public string Nom { get; set; }
	}
	class RegionViewModel : INomAndId
	{
		public int Id { get; set; }
		public string Nom { get; set; }
	}
	class SecteurDActiviteViewModel : INomAndId
	{
		public int Id { get; set; }
		public string Nom { get; set; }
	}
	class FicheArticleViewModel : INomAndId
	{
		public int Id { get; set; }
		public string Nom { get; set; }
	}
