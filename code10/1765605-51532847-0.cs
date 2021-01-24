	using System.Data.Entity;
	namespace ADMMassUploader
	{
		[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
		public class ApplicationDbContext : DbContext
		{
			public ApplicationDbContext() : base("MySqlConnection")
			{
			}
			public static ApplicationDbContext Create()
			{
				return new ApplicationDbContext();
			}
			public DbSet<adm_main> AdmMain { get; set; }
		}
	}
