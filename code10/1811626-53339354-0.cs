    using System;
    using System.Data.SqlClient;
    
    
    namespace car_database
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
    
    
                string connstring = "Data Source=.\\SqlExpress; Initial Catalog=carsale; Integrated Security=True";
    
                protected BtnView(object sender, EventArgs e)
                {
                    SqlConnection myConnection = new SqlConnection(connstring);
                    try
                    {
                        myConnection.Open();
                        string query = "select model ,price from car where Id =@carid";
    
                        SqlCommand mycmd = new SqlCommand(query, myConnection);
    
                        int carid1;
    
                        if (!int.TryParse(TextBox1.Text, out carid1))
                        { Label1.Text = "please enter a numerac ID!"; }
    
                        else
                        {
                            mycmd.Parameters.Add("@carid", System.Data.SqlDbType.Int);
                            mycmd.Parameters["@carid"].Value = carid1;
    
                            SqlDataReader reader = mycmd.ExecuteReader();
    
                            if (reader.Read())
                            {
                                Label1.Text = "Model:" + reader["model"] + "<br/>" + "price:" + (string)reader["price"];
    
                            }
    
                            else
                            {
                                Label1.Text = "no car has this id ";
    
                            }
    
                            reader.Close();
                        }
    
                    }
                    catch (Exception ex)
                    {
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Text = ex.Message;
    
                    }
                    finally
                    {
    
                        myConnection.Close();
    
                    }
    
                }
   
        }
    }
