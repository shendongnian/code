	public class Student                  
	{ 
		public string Name { get; set; }
		public int CountryCode { get; set; }
		public int BranchCode  { get; set; }
		public int Code { get; set; }
	}
	
	public class StudentComparer : IEqualityComparer<Student>
	{
		public bool Equals(Student x, Student y)
		{ 
			if (Object.ReferenceEquals(x, y)) return true;
			
			return x != null 
					&& y != null 
					&& x.CountryCode.Equals(y.CountryCode) 
					&& x.BranchCode.Equals(y.BranchCode);
		}
		public int GetHashCode(Student obj)
		{
			int hashCountryCode = obj.CountryCode.GetHashCode();
			int hashBranchCode  = obj.BranchCode.GetHashCode();
			return hashCountryCode ^ hashBranchCode;
		}
	}
    var toInstertInB = a.Except(b, new StudentComparer());
