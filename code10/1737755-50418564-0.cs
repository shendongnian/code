    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Collections;
    using YourCoffeeShop.App_Code;
    namespace YourCoffeeShop.App_Code
    {
    	public static class ConnectionClass
    	{
    		private static SqlConnection conn;
    		private static SqlCommand command;
    		static ConnectionClass()
    		{
    			string connectionString = ConfigurationManager.ConnectionStrings["cafeaconnection"].ToString();
    				conn = new SqlConnection(connectionString);
    			command = new SqlCommand("", conn);
    		}
    		public static ArrayList GetCafeaByType(string cafeaType)
    		{
    			ArrayList list = new ArrayList();
    			string query = string.Format("SELECT * FROM tipuridecafea WHERE tip LIKE '{0}'", cafeaType);
    			try
    			{
    				conn.Open();
    				command.CommandText = query;
    				SqlDataReader reader = command.ExecuteReader();
    				while(reader.Read())
    				{
    					int id = reader.GetInt32(0);
    					string nume = reader.GetString(1);
    					string tip = reader.GetString(2);
    					double pret = reader.GetDouble(3);
    					string roast = reader.GetString(4);
    					string tara = reader.GetString(5);
    					string imagine = reader.GetString(6);
    					string review = reader.GetString(7);
    					cafeacs tipuridecafea = new cafeacs(id, nume, tip, pret, roast, tara, imagine, review);
    					list.Add(tipuridecafea);
    				}
    			}
    			finally
    			{
    				conn.Close();
    			}
    			return list;
    		}
