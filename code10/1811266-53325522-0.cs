    IEnumerable<PersonRegistrationInformationTableInformation> results = (from data in (from participant_app in DBContext.PARTICIPANT_APPLICATION
                                                                            join people_vendor in DBContext.PEOPLE_VENDORS on participant_app.PEOPLE_ID equals people_vendor.PEOPLE_VENDORS_ID into tmppeople_vendor
                                                                            from people_vendor in tmppeople_vendor.DefaultIfEmpty()
                                                                            join reg_member_supp_app in DBContext.REG_MEMBER_SUPP_APP
                                                                            on new { REG_MEMBER_SUPP_APP_ID = (participant_app.REG_MEMBER_SUPP_APP_ID ?? -1), ELIG_DECISION_ICD = (int?)10591 }
                                                                            equals new { reg_member_supp_app.REG_MEMBER_SUPP_APP_ID, reg_member_supp_app.ELIG_DECISION_ICD } into tmpreg_member
                                                                            from reg_member_supp_app in tmpreg_member.DefaultIfEmpty()
                                                                            join reg_trainer_supp_app in DBContext.REG_TRAINER_SUPP_APP
                                                                            on new { REG_TRAINER_SUPP_APP_ID = (participant_app.REG_TRAINER_SUPP_APP_ID ?? -1), ELIG_DECISION_ICD = (int?)10591 }
                                                                            equals new { reg_trainer_supp_app.REG_TRAINER_SUPP_APP_ID, reg_trainer_supp_app.ELIG_DECISION_ICD } into tmpreg_trainer
                                                                            from reg_trainer_supp_app in tmpreg_trainer.DefaultIfEmpty()
                                                                            where reg_member_supp_app.RENEW_ELIG_DATE >= DateTime.Today.Date
                                                                            && reg_trainer_supp_app.RENEW_ELIG_DATE >= DateTime.Today.Date
                                                                            select new PersonRegistrationInformationTableInformation()
                                                                            {
                                                                                PeopleID = !string.IsNullOrEmpty(participant_app.PEOPLE_ID) ? participant_app.PEOPLE_ID.ToUpper().Trim() : null,
                                                                                FirstName = !string.IsNullOrEmpty(people_vendor.FIRST_NAME) ? people_vendor.FIRST_NAME.Trim() : null,
                                                                                LastName = !string.IsNullOrEmpty(people_vendor.LAST_NAME) ? people_vendor.LAST_NAME.Trim() : null,
                                                                                RegistryMemberSupplementApplication = reg_member_supp_app,
                                                                                RegistryTrainerSupplementApplication = reg_trainer_supp_app,
                                                                            })
                                                              
    IEnumerable<PersonRegistrationInformation> tableinfo = from data in results
                                                           group data by data.PeopleID into grp_data
                                                              select new PersonRegistrationInformation()
                                                              {
                                                                  PeopleID = grp_data.Key,
                                                                  FirstName = grp_data.FirstOrDefault().FirstName,
                                                                  LastName = grp_data.FirstOrDefault().LastName,
                                                                  RegistryMemberApplications = grp_data.Select(data => new RegistryMemberSupplementApplication()
                                                                  {
                                                                      RegistryMemberSupplementApplicationID = data.RegistryMemberSupplementApplication.REG_MEMBER_SUPP_APP_ID,
                                                                      ApplicationTypeICD = data.RegistryMemberSupplementApplication.APPL_TYPE_ICD,
                                                                      ReceiptDate = data.RegistryMemberSupplementApplication.RECEIPT_DATE,
                                                                      ApplicantSignedDate = data.RegistryMemberSupplementApplication.APPLICANT_SIGNED_DATE,
                                                                      ParentSignedDate = data.RegistryMemberSupplementApplication.PARENT_SIGNED_DATE,
                                                                      BasicTranscriptReviewICD = data.RegistryMemberSupplementApplication.BASIC_TRANSCRIPT_REVIEW_ICD,
                                                                      BasicTranscriptStatusICD = data.RegistryMemberSupplementApplication.BASIC_TRANSCRIPT_STATUS_ICD,
                                                                      TranscriptsReadyDate = data.RegistryMemberSupplementApplication.TRANSCRIPTS_READY_DATE,
                                                                      SubmitPreviousTrainingICD = data.RegistryMemberSupplementApplication.SUBMIT_PREV_TRAIN_ICD,
                                                                      HowLearnICD = data.RegistryMemberSupplementApplication.HOW_LEARN_ICD,
                                                                      IsRenewal = !string.IsNullOrEmpty(data.RegistryMemberSupplementApplication.RENEWAL_FG) ? (bool?)data.RegistryMemberSupplementApplication.RENEWAL_FG.ToUpper().Trim().Equals("Y") : null,
                                                                      IsReconsideration = !string.IsNullOrEmpty(data.RegistryMemberSupplementApplication.RECONSIDERATION_FG) ? (bool?)data.RegistryMemberSupplementApplication.RECONSIDERATION_FG.ToUpper().Trim().Equals("Y") : null,
                                                                      ReleaseOfInformationICD = data.RegistryMemberSupplementApplication.RELEASE_INFO_ICD,
                                                                      PersonJobID = data.RegistryMemberSupplementApplication.PERSON_JOB_ID,
                                                                      EligibilityDecisionICD = data.RegistryMemberSupplementApplication.ELIG_DECISION_ICD,
                                                                      EligibilityDenialReasonICD = data.RegistryMemberSupplementApplication.ELIG_DENIAL_REASON_ICD,
                                                                      EligibilityDecisionDate = data.RegistryMemberSupplementApplication.ELIG_DECISION_DATE,
                                                                      CurrentEligibilityDate = data.RegistryMemberSupplementApplication.CURR_ELIG_DATE,
                                                                      RenewEligibilityDate = data.RegistryMemberSupplementApplication.RENEW_ELIG_DATE,
                                                                      RenewNoticeDate = data.RegistryMemberSupplementApplication.RENEW_NOTICE_DATE,
                                                                      ParticipantApplicationID = data.RegistryMemberSupplementApplication.PARTICIPANT_APPLICATION_ID,
                                                                      PendingType = data.RegistryMemberSupplementApplication.PENDING_TYPE,
                                                                      ReferringProgram = !string.IsNullOrEmpty(data.RegistryMemberSupplementApplication.REFERRING_PROGRAM) ? data.RegistryMemberSupplementApplication.REFERRING_PROGRAM.Trim() : null,
                                                                      BTRCompletedDate = data.RegistryMemberSupplementApplication.BTR_COMPLETED_DATE,
                                                                      CreateDate = data.RegistryMemberSupplementApplication.CREATE_DATE,
                                                                      CreateUser = !string.IsNullOrEmpty(data.RegistryMemberSupplementApplication.CREATE_USER) ? data.RegistryMemberSupplementApplication.CREATE_USER.Trim() : null,
                                                                      UpdateDate = data.RegistryMemberSupplementApplication.UPDATE_DATE,
                                                                      UpdateUser = !string.IsNullOrEmpty(data.RegistryMemberSupplementApplication.UPDATE_USER) ? data.RegistryMemberSupplementApplication.UPDATE_USER.Trim() : null,
                                                                      IsDeleted = data.RegistryMemberSupplementApplication.DELETED_IND.ToUpper().Trim().Equals("Y"),
                                                                  }),
                                                                  RegistryTrainerApplications = grp_data.Select(data=> new RegistryTrainerSupplementApplication()
                                                                  {
                                                                      RegistryTrainerSupplementApplicationID = data.RegistryTrainerSupplementApplication.REG_TRAINER_SUPP_APP_ID,
                                                                      ApplicationTypeICD = data.RegistryTrainerSupplementApplication.APPL_TYPE_ICD,
                                                                      ReceiptDate = data.RegistryTrainerSupplementApplication.RECEIPT_DATE,
                                                                      ApplicantSignedDate = data.RegistryTrainerSupplementApplication.APPLICANT_SIGNED_DATE,
                                                                      ReleaseOfInformationICD = data.RegistryTrainerSupplementApplication.RELEASE_INFO_ICD,
                                                                      EligibilityDecisionICD = data.RegistryTrainerSupplementApplication.ELIG_DECISION_ICD,
                                                                      EligibilityDecisionDate = data.RegistryTrainerSupplementApplication.ELIG_DECISION_DATE,
                                                                      EligibilityDenialReasonICD = data.RegistryTrainerSupplementApplication.ELIG_DENIAL_REASON_ICD,
                                                                      RenewEligibilityDate = data.RegistryTrainerSupplementApplication.RENEW_ELIG_DATE,
                                                                      RenewNoticeDate = data.RegistryTrainerSupplementApplication.RENEW_NOTICE_DATE,
                                                                      TrainerID = data.RegistryTrainerSupplementApplication.TRAINER_ID,
                                                                      PendingType = data.RegistryTrainerSupplementApplication.PENDING_TYPE,
                                                                      CurrentEligibilityDate = data.RegistryTrainerSupplementApplication.CURR_ELIG_DATE,
                                                                      CreateDate = data.RegistryTrainerSupplementApplication.CREATE_DATE,
                                                                      CreateUser = !string.IsNullOrEmpty(data.RegistryTrainerSupplementApplication.CREATE_USER) ? data.RegistryTrainerSupplementApplication.CREATE_USER.Trim() : null,
                                                                      UpdateDate = data.RegistryTrainerSupplementApplication.UPDATE_DATE,
                                                                      UpdateUser = !string.IsNullOrEmpty(data.RegistryTrainerSupplementApplication.UPDATE_USER) ? data.RegistryTrainerSupplementApplication.UPDATE_USER.Trim() : null,
                                                                      IsDeleted = data.RegistryTrainerSupplementApplication.DELETED_IND.ToUpper().Trim().Equals("Y"),
                                                                  })
                                                                 });
