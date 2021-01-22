    using System.Data.SqlClient;
    using System.Numerics;
    using System.Net;
    using System.Text;
    public class Form1 {
    	
    	private void Form1_Load(object sender, System.EventArgs e) {
    		string ip = "8.8.8.8";
    		this.IP2Location(ip);
    	}
    	
    	private void IP2Location(string myip) {
    		IPAddress address = null;
    		if (IPAddress.TryParse(myip, address)) {
    			byte[] addrBytes = address.GetAddressBytes();
    			this.LittleEndian(addrBytes);
    			UInt32 ipno = 0;
    			ipno = BitConverter.ToUInt32(addrBytes, 0);
    			string sql = "SELECT TOP 1 * FROM ip2location_db1 WHERE ip_to >= \'" + ipno.ToString() + "\'";
    			object conn = new SqlConnection("Server=yourserver;Database=yourdatabase;User Id=youruserid;Password=yourpassword;");
    			object comm = new SqlCommand(sql, conn);
    			SqlDataReader reader;
    			comm.Connection.Open();
    			reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
    			int x = 0;
    			object sb = new StringBuilder(250);
    			if (reader.HasRows) {
    				if (reader.Read()) {
    					for (x = 0; (x <= (reader.FieldCount() - 1)); x++) {
    						sb.Append((reader.GetName(x) + (": " + (reader.GetValue(x) + "\r\n"))));
    					}
    				}
    			}
    			
    			reader.Close();
    			MsgBox(sb.ToString());
    		}
    		
    	}
    	
    	private void LittleEndian(ref byte[] byteArr) {
    		if (BitConverter.IsLittleEndian) {
    			List<byte> byteList = new List<byte>(byteArr);
    			byteList.Reverse();
    			byteArr = byteList.ToArray();
    		}
    		
    	}
    }
