        public static System.Data.DataTable FilterCandidates(System.Data.DataTable FullCandidateData, System.Data.DataTable RequiredCandidateIDs)
        {
            System.Data.DataTable reqCandidateData = new System.Data.DataTable();
            try
            {
                  var reqCandidateDt = (from candidateRow in FullCandidateData.AsEnumerable()
                                                    join reqCandidateRow in RequiredCandidateIDs.AsEnumerable()
                                                    on candidateRow["Candidate_ID"].ToString() equals reqCandidateRow["Candidate_ID"].ToString()
                                                    select candidateRow);
                
                     if (reqCandidateDt.Count() > 0)
                     {
                       reqCandidateData = reqCandidateDt.CopyToDataTable();
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
                     var reqCandidateDt = (from candidateRow in FullCandidateData.AsEnumerable()
                                                join reqCandidateRow in RequiredCandidateIDs.AsEnumerable()
                                                on
                                                new { CandidateId = candidateRow["Candidate_ID"].ToString(), Job_Id = candidateRow["Job_ID"].ToString() }
                                                equals
                                                new { CandidateId = reqCandidateRow["Candidate_ID"].ToString(), Job_Id = reqCandidateRow["Job_Id"].ToString() }
                                                select candidateRow);
            
                if (reqCandidateDt.Count() > 0)
                {
                    reqCandidateData = reqCandidateDt.CopyToDataTable();
                }
            
            
              }
              catch (Exception ex)
              {
            
              }
              return reqCandidateData;
      }
