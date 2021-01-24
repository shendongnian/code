    public class Employee
    {
        static string databaseString = "";
        public int Id { get { return _Id; } } //This is property
        public string Name { get { return _Name; } set { _Name = value; } } //This is property
        private int _Id; //This is private variable used by property
        private string _Name; //This is private variable used by property
        public Employee()
        {
            //Constructor used to create empty object
        }
        public Employee(int Id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(databaseString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT NAME FROM Employee WHERE ID = @ID", con))
                    {
                        cmd.Parameters.AddWithValue("@ID", Id);
                        SqlDataReader dr = cmd.ExecuteReader();
                        //I am usin IF(dr.Read()) instead of WHILE(dr.Read()) since i want to read only first row.
                        if (dr.Read())
                        {
                            this._Id = Id;
                            this._Name = dr[0].ToString();
                        }
                        else
                        {
                            System.Windows.Forms.MessageBox.Show("There was no Employee with that ID in database!");
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        public void Save(bool showMessage)
        {
            using (SqlConnection con = new SqlConnection(databaseString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Employee SET NAME = @N WHERE ID = @ID", con))
                {
                    cmd.Parameters.AddWithValue("@N", this._Name);
                    cmd.Parameters.AddWithValue("@ID", this._Id);
                    cmd.ExecuteNonQuery();
                    if (showMessage)
                        System.Windows.Forms.MessageBox.Show("Employee saved!");
                }
            }
        }
        public static void Create(string Name, bool showMessage = true)
        {
            using (SqlConnection con = new SqlConnection(databaseString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Employee (ID, NAME) VALUES (COALESCE(MAX(ID), 1), @NAME)", con))
                {
                    cmd.ExecuteNonQuery();
                    if (showMessage)
                        System.Windows.Forms.MessageBox.Show("New Employee created!");
                }
            }
        }
    }
