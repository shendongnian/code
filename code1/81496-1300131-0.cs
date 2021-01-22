    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Data;
    using System.Text;
    
    namespace Serial
    {
    	public class Ser
    	{
    		public static byte[] StrToByteArray(string str)
    		{
    			UTF8Encoding  encoding = new UTF8Encoding ();
    			return encoding.GetBytes(str);
    		}
    
    		public static string ByteArrayToStr(byte[] barr)
    		{
    			UTF8Encoding  encoding = new UTF8Encoding ();
    			return encoding.GetString(barr, 0, barr.Length);
    		}
    
    		public static void Main(String[] args)
    		{
    			DataTable dt = new DataTable();
    			DataRow dr;
    
    			dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
    			dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
    			dt.Columns.Add(new DataColumn("DateTimeValue", typeof(DateTime)));
    			dt.Columns.Add(new DataColumn("BooleanValue", typeof(bool)));
    
    			for (int i = 1; i <= 1; i++) 
    			{
    	                
    				dr = dt.NewRow();
    
    				dr[0] = i;
    				dr[1] = "Item " + i.ToString();
    				dr[2] = DateTime.Now;
    				dr[3] = (i % 2 != 0) ? true : false;
    
    				dt.Rows.Add(dr);
    			}
    
    			//Serialize
    			BinaryFormatter bformatter = new BinaryFormatter();
    			MemoryStream  stream = new MemoryStream();
    
    			string s;
    			bformatter.Serialize(stream, dt);
    			byte[] b = stream.ToArray();
    			s = ByteArrayToStr(b);
    			stream.Close();
    			dt = null;
    
    			//Now deserialise
    			bformatter = new BinaryFormatter();
    			byte[] d;
    			d = StrToByteArray(s);
    			stream = new MemoryStream(d);
    			dt = (DataTable)bformatter.Deserialize(stream);
    			stream.Close();
    		}
    	}
    }
