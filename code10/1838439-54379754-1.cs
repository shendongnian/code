	public partial class Fm_principal : Form
	{
		public SqlConnection connexion_BDD()
		{
			//Connection base de donnée
			string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Database;Trusted_Connection=true";
			SqlConnection connection = new SqlConnection(connectionString);
			try
			{
				connection.Open();
				return connection;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return connection;
			}
		}
		public Fm_principal()
		{
			InitializeComponent();
		}
		private void cb_test_Click(object sender, EventArgs e)
		{
			using (var connection = connection_BDD())
			{
				string request = "SELECT ref_pdt FROM produits";
				using (var command = new SqlCommand(request, connection))
				{
					using (var dataReader = command.ExecuteReader())
					{
						while (dataReader.Read())
						{
							cb_test.Items.Add(dataReader["ref_pdt"]);
						}
					}
				}
			}
		}
	}
