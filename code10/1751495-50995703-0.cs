	public class AgreementRepository
	{
		private const string FileLocation = @"I:\Security Awareness Signed Users\Signed Users.txt";
		private const char Separator = '\t';
		public void AppendAgreementForCurrentUser()
		{
			string currentUser = GetCurrentUser();
			using (StreamWriter sw = File.AppendText(FileLocation))
			{
				sw.WriteLine($"{currentUser}{Separator}{DateTime.Now:O}");
			}
		}
		public DateTime? GetLastAgreementForCurrentUser()
		{
			string currentUser = GetCurrentUser();
			if (File.Exists(FileLocation) == false)
			{
				return null;
			}
			var lastAgreement = File.ReadLines(FileLocation)
				.Select(x => x.Split(Separator))
				.Where(x => x.Length == 2 && string.Equals(x[0], currentUser, StringComparison.CurrentCultureIgnoreCase))
				.Select(x => GetDateTime(x[1]))
				.Max();
			return lastAgreement;
		}
		private static DateTime? GetDateTime(string input)
		{
			DateTime result;
			if (DateTime.TryParse(input, out result))
			{
				return result;
			}
			return null;
		}
		private static string GetCurrentUser()
		{
			return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
		}
	}
