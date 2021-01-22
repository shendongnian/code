     public class DateClass
     {
          public string AvgDate { get; set; }
          public int MarkerID { get; set; }
     }
     ...
 
     var dates = new List<DateClass>();
     if (reader.HasRows)
     {
           while (reader.Read())
           {
               var date = new DateClass { AvgDate = reader["AvgDate"].ToString(), MarkerID = (int)reader["MarkerID"] };
                dates.Add( date );
           }
     }
     var stream = new MemoryStream();
     var serializer = new DataContractJsonSerializer( typeof(DateClass) );
     serializer.WriteObject( stream, dates );
     stream.Seek( 0, SeekOrigin.Begin );
     return stream.ToString();
