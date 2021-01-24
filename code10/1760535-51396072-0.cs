    class String_String
    {
    	public _string1 { get; set; }
    	public _string2 { get; set; }
    }
    
    
    try
    {
        using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\TimeKeeping.mdf;Integrated Security=True;User Instance=False"))
        {
            conn.Open();
    
            using (SqlCommand cmd = new SqlCommand(
            "SELECT people, SUM(minTime) FROM timeTable ASC GROUP BY PEOPLE ORDER BY people", conn))
            {
    			SqlDataReader dr = cmd.ExecuteReader();
    			
    			List<String_String> list = new List<String_String>();
    			
    			while(dr.Read())
    			{
    				list.Add(new List<String_String> { _string1 = dr[0].ToString(), _string2 = dr[1].ToString() });
    			}
    			
    			
    			lstVwPeopleTime.DataSource = list;
    			lstVwPeopleTime.DisplayMember = "_string2";
    			lstVwPeopleTime.ValueMember = "_string1";
            }
        }
    }
    catch (SqlException ex) { MessageBox.Show(ex.Message); }
    catch (System.Exception ex) { MessageBox.Show(ex.Message); }
