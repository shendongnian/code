	class Patient
	{
		public int      UserID     { get; set; }
		public int      PracticeID { get; set; }
		public string   FirstName  { get; set; }
		public string   LastName   { get; set; }
		public DateTime DOB        { get; set; }
		public string   Social     { get; set; }
		public override string ToString()
		{
			return string.Format("{0} {1} {2}", UserID, FirstName, LastName);
		}
	}
	
	class PatientRepository
	{
		static private readonly List<Patient> sourceData = new List<Patient>
		{
			new Patient
			{
				UserID = 1, PracticeID = 10, FirstName = "John", LastName = "Doe", DOB = DateTime.Parse("1/2/1968"), Social="123456789"
			},
			new Patient
			{
				UserID = 2, PracticeID = 10, FirstName = "Jane", LastName = "Doe", DOB = DateTime.Parse("1/2/1958"), Social="123456790"
			},
			new Patient
			{
				UserID = 3, PracticeID = 10, FirstName = "John", LastName = "Carson", DOB = DateTime.Parse("4/1/1938"), Social="123456791"
			}
		};
		
		public IEnumerable<Patient> FindPatients(Func<Patient,bool> criteria)
		{
			return sourceData
				.Where (criteria);
		}
		public Patient FindPatient(Func<Patient,bool> criteria)
		{
			return sourceData
				.Single(criteria);
		}
	}
						
	public class Program
	{
		public static void Main()
		{
			//Get a reference to the data store
			var patients = new PatientRepository();
			
			Console.WriteLine("Multiple record search");
			var results = patients.FindPatients
			( 
				p => p.LastName == "Doe" 
			);
			foreach (var p in results)
			{
				Console.WriteLine(p);
			}
			
			Console.WriteLine("Single record search");
			var singleResult = patients.FindPatient
			(
				p => p.UserID == 1
			);
			Console.WriteLine(singleResult);
		}
	}
