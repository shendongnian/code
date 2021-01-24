    public List<TestViewModel> get_List_Of_Test(int SubjectId, int ProgramLevelId, int AcademicTerm, int AcademicSession,
                int ProgramId, int status)
            {
                List<TestViewModel> sList = new List<TestViewModel>();
                try
                {
                    using (SqlConnection con = new SqlConnection(conn))
                    {
                        con.Open();
                        SqlCommand oComm = new SqlCommand();
                        using (oComm)
                        {
                            oComm.Connection = con;
                            oComm.CommandType = CommandType.StoredProcedure;
                            oComm.CommandText = "CMS_Test_GetList";
    
                            oComm.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.Int));
                            oComm.Parameters["@SubjectId"].Value = SubjectId == 0 ? System.Data.SqlTypes.SqlInt32.Null : SubjectId;
    
                            oComm.Parameters.Add(new SqlParameter("@ProgramId", SqlDbType.Int));
                            oComm.Parameters["@ProgramId"].Value = ProgramId == 0 ? System.Data.SqlTypes.SqlInt32.Null : ProgramId;
    
                            oComm.Parameters.Add(new SqlParameter("@ProgramLevelId", SqlDbType.Int));
                            oComm.Parameters["@ProgramLevelId"].Value = ProgramLevelId == 0 ? System.Data.SqlTypes.SqlInt32.Null : ProgramLevelId;
    
                            oComm.Parameters.Add(new SqlParameter("@AcademicSession", SqlDbType.Int));
                            oComm.Parameters["@AcademicSession"].Value = AcademicSession == 0 ? System.Data.SqlTypes.SqlInt32.Null : AcademicSession;
    
                            oComm.Parameters.Add(new SqlParameter("@AcademicTerm", SqlDbType.Int));
                            oComm.Parameters["@AcademicTerm"].Value = AcademicTerm == 0 ? System.Data.SqlTypes.SqlInt32.Null : AcademicTerm;
    
                            oComm.Parameters.Add(new SqlParameter("@AddedBy", SqlDbType.Int));
                            oComm.Parameters["@AddedBy"].Value = MembershipHelper.GetActiveUser().Teacher.IsAdmin ? System.Data.SqlTypes.SqlInt32.Null : MembershipHelper.GetActiveUserId;
    
                            oComm.Parameters.Add(new SqlParameter("@EntityStatus", SqlDbType.Int));
                            oComm.Parameters["@EntityStatus"].Value = status;
    
                            SqlDataReader rdr = oComm.ExecuteReader();
                            if (rdr.HasRows)
                            {
                                int _sn = 0;
                                while (rdr.Read())
                                {
                                    int publicStatus = _rdrHelper.getOrdinalInt32Value(rdr, "EntityStatus");
                                    _sn++;
                                    TestViewModel qList = new TestViewModel();
                                    qList.ProgramLevelId = _rdrHelper.getOrdinalInt32Value(rdr, "ProgramLevel");
                                    qList.ProgramLevelText = Extensions.ListEnums.GetProgramLevel().Skip(qList.ProgramLevelId - 1).First().Text;
                                    qList.AcademicTermId = _rdrHelper.getOrdinalInt32Value(rdr, "AcademicTerm");
                                    qList.AcademicTermText = Extensions.ListEnums.GetTermChoice().Skip(qList.AcademicTermId - 1).First().Text;
                                    qList.TestTitle = _rdrHelper.GetOrdinalStringValue(rdr, "Title");
                                    qList.ClassId = _rdrHelper.getOrdinalInt32Value(rdr, "ClassId");
                                    qList.ClassName = _rdrHelper.GetOrdinalStringValue(rdr, "ClassName");
                                    qList.SubjectName = _rdrHelper.GetOrdinalStringValue(rdr, "SubjectName");
                                    qList.SessionId = _rdrHelper.getOrdinalInt32Value(rdr, "Session");
                                    qList.TestId = _rdrHelper.getOrdinalInt32Value(rdr, "Id");
                                    qList.Duration = _rdrHelper.getOrdinalInt32Value(rdr, "Duration");
                                    qList.Status = _rdrHelper.getOrdinalBooleanValue(rdr, "Status");
                                    qList.QuestionCount = _rdrHelper.getOrdinalInt32Value(rdr, "QuestionNumber");
                                    qList.TestSn = _sn;
                                    qList.ResultExists = _rdrHelper.getOrdinalInt32Value(rdr, "ResultsCount") > 0;
                                    qList.AddedBy = _rdrHelper.getOrdinalInt32Value(rdr, "AddedBy");
                                    qList.Test.StartDateTime = _rdrHelper.getNullableOrdinalDatetimeValue(rdr, "StartDateTime");
                                    qList.Test.EndDateTime = _rdrHelper.getNullableOrdinalDatetimeValue(rdr, "EndDateTime");
                                    qList.Test.EntityStatus = publicStatus;
                                    sList.Add(qList);
                                }
                            }
                            con.Close();
                        }
    
                    }
                }
