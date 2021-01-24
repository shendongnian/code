        public bool insert_New_Test(string TestName, int Duration, int SessionYear, int ClassId, int SubjectId, bool Status, int AddedBy,
                    int ProgramLevelId, int AcademicTerm, int questionSetUpType, out int id, DateTime startDateTime, DateTime endDateTime, int? testType)
                {
                    bool functionReturnValue = false;
                    id = 0;
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
                                oComm.CommandText = "CMS_Test_Insert";
        
                                oComm.Parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar));
                                oComm.Parameters["@Title"].Value = TestName;
        
                                oComm.Parameters.Add(new SqlParameter("@SubjectId", SqlDbType.Int));
                                oComm.Parameters["@SubjectId"].Value = SubjectId;
        
                                oComm.Parameters.Add(new SqlParameter("@ClassId", SqlDbType.Int));
                                oComm.Parameters["@ClassId"].Value = ClassId;
        
                                oComm.Parameters.Add(new SqlParameter("@Session", SqlDbType.Int));
                                oComm.Parameters["@Session"].Value = SessionYear;
        
                                oComm.Parameters.Add(new SqlParameter("@ProgramLevelId", SqlDbType.Int));
                                oComm.Parameters["@ProgramLevelId"].Value = ProgramLevelId;
        
                                oComm.Parameters.Add(new SqlParameter("@AcademicTerm", SqlDbType.Int));
                                oComm.Parameters["@AcademicTerm"].Value = AcademicTerm;
        
                                oComm.Parameters.Add(new SqlParameter("@Duration", SqlDbType.Int));
                                oComm.Parameters["@Duration"].Value = Duration;
        
                                oComm.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit));
                                oComm.Parameters["@Status"].Value = Status;
        
                                oComm.Parameters.Add(new SqlParameter("@AddedBy", SqlDbType.Int));
                                oComm.Parameters["@AddedBy"].Value = AddedBy;
        
        
                                oComm.Parameters.Add(new SqlParameter("@QuestionSetupType", SqlDbType.Int));
                                oComm.Parameters["@QuestionSetupType"].Value = questionSetUpType;
        
                                if (startDateTime > DateTime.MinValue)
                                {
                                    oComm.Parameters.Add(new SqlParameter("@StartDateTime", SqlDbType.DateTime));
                                    oComm.Parameters["@StartDateTime"].Value = startDateTime;
                                }
                                if (endDateTime > DateTime.MinValue)
                                {
                                    oComm.Parameters.Add(new SqlParameter("@EndDateTime", SqlDbType.DateTime));
                                    oComm.Parameters["@EndDateTime"].Value = endDateTime;
                                }
        
                                oComm.Parameters.Add(new SqlParameter("@TestType", SqlDbType.Int));
                                oComm.Parameters["@TestType"].Value = testType;
        
                                oComm.Parameters.Add(new SqlParameter("@Success", SqlDbType.Bit));
                                oComm.Parameters["@Success"].Direction = ParameterDirection.Output;
        
                                oComm.Parameters.Add(new SqlParameter("@TestId", SqlDbType.Int));
                                oComm.Parameters["@TestId"].Direction = ParameterDirection.Output;
                                oComm.ExecuteNonQuery();
                                functionReturnValue = Convert.ToBoolean(oComm.Parameters["@Success"].Value);
                                id = Convert.ToInt32(oComm.Parameters["@TestId"].Value);
        
                            }
                            con.Close();
                        }
        
                    }
                    catch (SqlException ex)
                    {
                        Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                        functionReturnValue = false;
                    }
                    return functionReturnValue;
        
                }
    
