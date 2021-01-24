    var insuredApplicationIDs = Result.Select(r => r.INSURED_APPLICATION_ID);
    var queryResaut = (from b in entities.USERS
                       join f in entities.Apps.Where(y => insuredApplicationIDs.Contains(y.INSURED_APPLICATION_ID)) on b.USERID equals f.USERID
                                            select new
                                            {
                                                USERID = b.USERID,
                                                //INSURED_APPLICATION_ID = queryresult.INSURED_APPLICATION_ID,
                                                //User
                                                USER_NAME = b.USER_NAME,
                                                INSURED_FIRST_NAME = b.INSURED_FIRST_NAME,
                                                INSURED_LAST_NAME = b.INSURED_LAST_NAME,
                                                INSURED_EMAIL = b.INSURED_EMAIL,
                                                //App_Information
                                            }).ToArray()
