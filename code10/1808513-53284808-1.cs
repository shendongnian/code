	public class DiseaseDto
	{
		public class Login
		{
			public bool IsValid
			{
				get;
				set;
			}
			public string Message
			{
				get;
				set;
			}
		}
		public class ListOfDiseas
		{
			public int DiseaseId
			{
				get;
				set;
			}
			public string Name
			{
				get;
				set;
			}
			public object DiseaseList
			{
				get;
				set;
			}
			public object GuidelineDiseaseList
			{
				get;
				set;
			}
			public bool IsReadOnly
			{
				get;
				set;
			}
			public object ListOfDiseaseTypes
			{
				get;
				set;
			}
		}
		public class Guideline
		{
			public int GuidelineId
			{
				get;
				set;
			}
			public string Name
			{
				get;
				set;
			}
			public string Type
			{
				get;
				set;
			}
			public List<ListOfDiseas> ListOfDiseases
			{
				get;
				set;
			}
			public string Url
			{
				get;
				set;
			}
			public string LatestVersionNumber
			{
				get;
				set;
			}
			public DateTime LastPublishedDate
			{
				get;
				set;
			}
			public string Language
			{
				get;
				set;
			}
			public string PublishedForRegion
			{
				get;
				set;
			}
		}
		public class RootObject
		{
			public Login Login
			{
				get;
				set;
			}
			public List<Guideline> Guidelines
			{
				get;
				set;
			}
		}
