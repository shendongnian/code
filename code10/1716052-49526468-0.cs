        public static System.Data.DataTable FilterCandidates(System.Data.DataTable FullCandidateData, System.Data.DataTable RequiredCandidateIDs)
    {
                 System.Data.DataTable reqCandidateData = new System.Data.DataTable();
                try
                {
                     reqCandidateData = (from candidateRow in FullCandidateData.AsEnumerable()
                                                join reqCandidateRow in RequiredCandidateIDs.AsEnumerable()
                                                on candidateRow["Candidate_ID"].ToString() equals reqCandidateRow["Candidate_ID"].ToString()
                                                select candidateRow).CopyToDataTable();
            
                 if (reqCandidateData.Rows.Count == 0)
                 {
                   //no rows found
                 }
            
            
           }
           catch (Exception ex)
           {
            
           }
           return reqCandidateData;
        }
 
        public static System.Data.DataTable FilterCandidates(System.Data.DataTable FullCandidateData, System.Data.DataTable RequiredCandidateIDs)
     {
            System.Data.DataTable reqCandidateData = new System.Data.DataTable();
            try
            {
                 reqCandidateData = (from candidateRow in FullCandidateData.AsEnumerable()
                                            join reqCandidateRow in RequiredCandidateIDs.AsEnumerable()
                                            on
                                            new { CandidateId = candidateRow["Candidate_ID"].ToString(), Job_Id = candidateRow["Job_ID"].ToString() }
                                            equals
                                            new { CandidateId = reqCandidateRow["Candidate_ID"].ToString(), Job_Id = reqCandidateRow["Job_Id"].ToString() }
                                            select candidateRow).CopyToDataTable();
        
            if (reqCandidateData.Rows.Count == 0)
            {
                            //no rows found
            }
        
        
          }
          catch (Exception ex)
          {
        
          }
          return reqCandidateData;
    }
