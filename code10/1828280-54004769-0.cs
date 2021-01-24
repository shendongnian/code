    var x=from n in d.Employee
         Where n.EmpId==10
        select n
        
                        StringBuilder sb = new StringBuilder();
                        StringBuilder abc = new StringBuilder();
        
         foreach (var master in x)
                    {
        
                        sb.Append(master.CANDIDATE_NAME + ",");
                        abc.Append(sb);
                        join_Body = new HrEmailsender()
                        {
             Body = "Hi," + abc +                   
                        };
