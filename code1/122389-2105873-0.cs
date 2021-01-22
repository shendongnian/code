        public List<EligibleClass> GetEligibles(string sConnectionString)
        {
            List<EligibleClass> alEligible = null;
            try
            {
                using (SqlConnection sConn = new SqlConnection(sConnectionString))
                {
                    sConn.Open();
                    using (SqlCommand sCmd = new SqlCommand())
                    {
                        sCmd.Connection = sConn;
                        sCmd.CommandText = "SELECT field1, field2 FROM ViewEligible";
                        using (SqlDataReader sqlReader = sCmd.ExecuteReader())
                        {
                            while (sqlReader.Read())
                            {
                                EligibleClass Person = new EligibleClass();
                                Person.field1 = sqlReader.GetString(0);
                                Person.field2 = sqlReader.GetString(1);
                                if (alEligible == null) alEligible = new List<EligibleClass>();
                                alEligible.Add(Person);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // do something.
            }
            return alEligible;
        }
