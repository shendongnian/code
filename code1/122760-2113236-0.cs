    public static IQueryable<tblSurvey> GetSurveysInState(SurveyDataContext surveyContext,
            FINDataContext finContext, string state)
        {
            string[] facility = (from f in finContext.tblLocContacts
                           where f.State == state
                           select f.LocationID).ToArray();
            return from survey in surveyContext.tblSurveys
                   where facility.Contains(survey.FacilityID)
                   select survey;
        }
