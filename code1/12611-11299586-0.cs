    public class TimeTool {
      private static readonly DateTime NODATE = new DateTime(1900, 1, 1);
    #if PocketPC
      [DllImport("coredll.dll")]
    #else
      [DllImport("kernel32.dll")]
    #endif
      static extern bool SetLocalTime([In] ref SYSTEMTIME lpLocalTime);
      public struct SYSTEMTIME {
        public short Year, Month, DayOfWeek, Day, Hour, Minute, Second, Millisecond;
        /// <summary>
        /// Convert form System.DateTime
        /// </summary>
        /// <param name="time">Creates System Time from this variable</param>
        public void FromDateTime(DateTime time) {
          Year = (short)time.Year;
          Month = (short)time.Month;
          DayOfWeek = (short)time.DayOfWeek;
          Day = (short)time.Day;
          Hour = (short)time.Hour;
          Minute = (short)time.Minute;
          Second = (short)time.Second;
          Millisecond = (short)time.Millisecond;
        }
        public DateTime ToDateTime() {
          return new DateTime(Year, Month, Day, Hour, Minute, Second, Millisecond);
        }
        public static DateTime ToDateTime(SYSTEMTIME time) {
          return time.ToDateTime();
        }
      }
      // read SQL Time and set time on device
      public static int SyncWithSqlTime(System.Data.SqlClient.SqlConnection con) {
        SYSTEMTIME systemTime = new SYSTEMTIME();
        DateTime sqlTime = NODATE;
        string sql = "SELECT GETDATE() AS [CurrentDateTime]";
        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, con)) {
          try {
            cmd.Connection.Open();
            System.Data.SqlClient.SqlDataReader r = cmd.ExecuteReader();
            while (r.Read()) {
              if (!r.IsDBNull(0)) {
                sqlTime = (DateTime)r[0];
              }
            }
          } catch (Exception) {
            return -1;
          }
        }
        if (sqlTime != NODATE) {
          systemTime.FromDateTime(sqlTime); // Convert to SYSTEMTIME
          if (SetLocalTime(ref systemTime)) { //Call Win32 API to set time
            return 1;
          }
        }
        return 0;
      }
    }
