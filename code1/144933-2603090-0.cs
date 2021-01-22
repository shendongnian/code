        public class MyCommandRunner {
          private SqlCommand cmd;
          public MyCommandRunner(string commandText) {
            cmd = new SqlCommand(commandText);
          }
            
          public void AddParameter(string name, string value) {
            if (value == null)
             cmd.Parameters.Add(name, DBNull.Value);
            else
              cmd.Parameters.Add(name, value);
          }
            
          // ... more AddParameter overloads
        }
