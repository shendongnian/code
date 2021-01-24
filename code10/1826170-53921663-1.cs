    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SqlClient;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string connStr = "Enter your connection string here";
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "WB_SetNotification";  //stored procdure name
                SqlParameter policyNumber = cmd.Parameters.Add(new SqlParameter("@PolicyNumber", SqlDbType.VarChar, 20));
                cmd.Parameters.Add(policyNumber);
                cmd.Parameters["@PolicyNumber"].Direction = ParameterDirection.Input;
                SqlParameter firstName = cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(firstName);
                cmd.Parameters["@FirstName"].Direction = ParameterDirection.Input;
                 SqlParameter lastName = cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.VarChar, 50));
                cmd.Parameters.Add(lastName);
                cmd.Parameters["@LastName"].Direction = ParameterDirection.Input;
                SqlParameter dob = cmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime));
                cmd.Parameters.Add(dob);
                cmd.Parameters["@DateOfBirth"].Direction = ParameterDirection.Input;
                XDocument doc = XDocument.Load(FILENAME);
                List<Policy> policies = doc.Descendants("Policy").Select(item => new Policy()
                {
                    PolNumber = (string)item.Element("PolNumber"),
                    FirstName = (string)item.Element("FirstName"),
                    LastName = (string)item.Element("LastName"),
                    BirthDate = (string)item.Element("BirthDate"),
                    MailType = (string)item.Element("MailType")
                }).ToList();
                foreach (Policy policy in policies)
                {
                    cmd.Parameters["@PolicyNumber"].Value  = policy.PolNumber;
                    cmd.Parameters["@FirstName"].Value = policy.FirstName;
                    cmd.Parameters["@LastName"].Value = policy.LastName;
                    cmd.Parameters["@DateOfBirth"].Value = policy.BirthDate;
                    cmd.ExecuteNonQuery();
                }
     
            }
            public class Policy
            {
                public string PolNumber { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string BirthDate { get; set; }
                public string MailType { get; set; }
            }
        }
    }
