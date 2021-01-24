	<%@ WebHandler Language="C#" Class="HectorsApp.HectorsHandler" %>
	using System;
	using System.Configuration;
	using System.Data;
	using System.Data.SqlClient;
	using System.Web;
	namespace HectorsApp
	{
		public class HectorsHandler : IHttpHandler
		{
			public void ProcessRequest(HttpContext ctxt)
			{
				// Request.QueryString["docid"].ToString(); 
				//string DocumentID = Request.QueryString["DocumentID"].ToString();
				string DocumentID = "9163736c-8064-11e8-ab16-2c44fd826130";
				string SessionId = "91494483-8064-11e8-ab16-2c44fd826130";
				//Connection and Parameters
				SqlParameter param1 = null;
				SqlParameter param2 = null;
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ProcessManagerConnectionString"].ToString()))
				{
					SqlCommand cmd = new SqlCommand("sp_getdoc", conn);
					cmd.CommandType = CommandType.StoredProcedure;
					param1 = new SqlParameter("@DocumentID", SqlDbType.NVarChar, 100);
					param2 = new SqlParameter("@SessionId", SqlDbType.NVarChar, 100);
					param1.Direction = ParameterDirection.Input;
					param2.Direction = ParameterDirection.Input;
					param1.Value = DocumentID;
					param2.Value = SessionId;
					cmd.Parameters.Add(param1);
					cmd.Parameters.Add(param2);
					//Open connection and fetch the data with reader
					conn.Open();
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SequentialAccess))
					{
						if (reader.Read())
						{
							//
							string doctype = reader["Extension"].ToString();
							string docname = reader["Docname"].ToString();
							//
							ctxt.Response.BufferOutput = false;
							ctxt.Response.Buffer = false;
							ctxt.Response.ContentType = doctype;
							ctxt.Response.AddHeader("Content-Disposition", "attachment; filename=" + docname);
							//Code for streaming the object while writing
							byte[] buffer = new byte[8040];
							long dataIndex = 0;
							while (ctxt.Response.IsClientConnected)
							{
								long bytesRead = reader.GetBytes(reader.GetOrdinal("Data"), dataIndex, buffer, 0, buffer.Length);
								if (bytesRead == 0)
								{
									break;
								}
								ctxt.Response.OutputStream.Write(buffer, 0, (int)bytesRead);
								ctxt.Response.OutputStream.Flush();
								dataIndex += bytesRead;
							}
						}
					}
				}
			}
			public bool IsReusable
			{
				get { return false; }
			}
		}
	}
