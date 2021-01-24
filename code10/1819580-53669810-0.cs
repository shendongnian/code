    cmd.Parameters.AddRange(new OleDbParameter[]
               {
                   new OleDbParameter("@UserName", txtUsn.Text),
                   new OleDbParameter("@UserPass", txtPass.Text),
                   ...
               });
