    private void TestInsertPerformance() {
      const int limit = 100000;
      using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=c:\testperf.db")) {
        conn.Open();
        using (SQLiteCommand comm = new SQLiteCommand()) {
          comm.Connection = conn;
          comm.CommandText = " create table test (n integer) ";
          comm.ExecuteNonQuery();
          Stopwatch s = new Stopwatch();
          s.Start();
          using (SQLiteTransaction tran = conn.BeginTransaction()) {
            for (int i = 0; i < limit; i++) {
              comm.CommandText = "insert into test values (" + i.ToString() + ")";
              comm.ExecuteNonQuery();
            }
            tran.Commit();
          }
          s.Stop();
          MessageBox.Show("time without parm " + s.ElapsedMilliseconds.ToString());
    
          SQLiteParameter parm = comm.CreateParameter();
          comm.CommandText = "insert into test values (?)";
          comm.Parameters.Add(parm);
          s.Reset();
          s.Start();
          using (SQLiteTransaction tran = conn.BeginTransaction()) {
            for (int i = 0; i < limit; i++) {
              parm.Value = i;
              comm.ExecuteNonQuery();
            }
            tran.Commit();
          }
          s.Stop();
          MessageBox.Show("time with parm " + s.ElapsedMilliseconds.ToString());
    
        }
        conn.Close();
      }
    }
