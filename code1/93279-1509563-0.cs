    namespace BLL
    {
        using System;
        using System.Data;
        using System.Data.SqlClient;
        [System.ComponentModel.DataObject]
        public class QuestionnaireDataObject
        {
            public static DataTable isQuestionnaireComplete(string strHash1, string strHash2, string strHash3)
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = Sql.getConnection())
                {
                    SqlCommand cmd =
                        new SqlCommand(
                            String.Format("SELECT Hash, IsComplete FROM UserDetails WHERE Hash IN ('{0}', '{1}', '{2}')",
                                          strHash1, strHash2, strHash3));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    da.Dispose();
                }
    
                return dt;
            }
        }
    }
