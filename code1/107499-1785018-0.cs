    var Questionnaire = from employmentQuestionnaire in context.tblEmploymentQuestionnaires
                        where employmentQuestionnaire.EmploymentQuestionnaireID == employmentQuestionnaireID
                        select new
                               {
                                   EmploymentQuestionnaireID = employmentQuestionnaire.EmploymentQuestionnaireID,
                                   PlanID = employmentQuestionnaire.PlanID,
                                   HasCommunityJob = employmentQuestionnaire.CommunityJob,
                                   HasPrevocServices = employmentQuestionnaire.PrevocServices,
                                   HasJobDevelopmentServices = employmentQuestionnaire.JobDevelopmentServices,
                                   WhoCreated = employmentQuestionnaire.InsertUser,
                                   WhenCreated = employmentQuestionnaire.InsertDate,
                                   WhoUpdated = employmentQuestionnaire.UpdateUser,
                                   WhenUpdated = employmentQuestionnaire.UpdateDate,
                                   AvgRatePay = employmentQuestionnaire.PrevocService.AvgRatePay,
                                   AvgHoursWeek = employmentQuestionnaire.PrevocService.AvgHoursWeek,
                                   PrevocGoal = employmentQuestionnaire.PrevocService.PrevocGoal,
                                   SkillsTaught = employmentQuestionnaire.PrevocService.SkillsTaught,
                                   SkillsLearned = employmentQuestionnaire.PrevocService.SkillsLearned,
                                   AnticipatedTransitionPlan = employmentQuestionnaire.PrevocService.AnticipatedTransitionPlans,
                                   AnticipatedEndDate = employmentQuestionnaire.PrevocService.AnticipatedEndDate,
                                   TypeWorkDesired = employmentQuestionnaire.JobDevelopmentService.TypeWorkDesired,
                                   NeedEmpServices = employmentQuestionnaire.JobDevelopmentService.NeedEmploymentServices,
                                   IsDVRProvidingServices = employmentQuestionnaire.JobDevelopmentService.DVRProvidingServices,
                                   DVRCurrentReferralExists = employmentQuestionnaire.JobDevelopmentService.DVRCurrentReferral
                                };
