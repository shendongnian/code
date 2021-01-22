        using (var context = MatrixDataContext.Create())
        {
                var empPlan = new tblEmploymentQuestionnaire
                                  {
                                      CommunityJob = communityJob,
                                      EmploymentQuestionnaireID = Guid.NewGuid(),
                                      InsertDate = DateTime.Now,
                                      InsertUser = user,
                                      JobDevelopmentServices = jobDevelopmentServices,
                                      JobDevelopmentService = new tblEmploymentJobDevelopmetService(),
                                      PrevocServices = prevocServices,
                                      PrevocService = new tblEmploymentPrevocService(),
                                      PrevocServicesID =empPrevocID,
                                      TransitionedPrevocToIntegrated =transitionedPrevocIntegrated,
                                      EmploymentServiceMatchPref = empServiceMatchPref 
                                  };
                context.tblEmploymentQuestionnaires.InsertOnSubmit(empPlan);
                context.SubmitChanges();
        }
