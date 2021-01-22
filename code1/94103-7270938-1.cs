    /// <summary>
    /// Amended date of birth cannot be greater than or equal to one month either side of original date of birth.
    /// </summary>
    /// <param name="dateOfBirth">Date of birth user could have amended.</param>
    /// <param name="originalDateOfBirth">Original date of birth to compare against.</param>
    /// <returns></returns>
    public JsonResult ValidateDateOfBirth(string dateOfBirth, string originalDateOfBirth)
    {
        DateTime dob, originalDob;
        bool isValid = false;
        if (DateTime.TryParse(dateOfBirth, out dob) && DateTime.TryParse(originalDateOfBirth, out originalDob))
        {
            int diff = ((dob.Month - originalDob.Month) + 12 * (dob.Year - originalDob.Year));
            switch (diff)
            {
                case 0:
                    // We're on the same month, so ok.
                    isValid = true;
                    break;
                case -1:
                    // The month is the previous month, so check if the date makes it a calendar month out.
                    isValid = (dob.Day > originalDob.Day);
                    break;
                case 1:
                    // The month is the next month, so check if the date makes it a calendar month out.
                    isValid = (dob.Day < originalDob.Day);
                    break;
                default:
                    // Either zero or greater than 1 month difference, so not ok.
                    isValid = false;
                    break;
            }
            if (!isValid)
                return Json("Date of Birth cannot be greater than one month either side of the date we hold.", JsonRequestBehavior.AllowGet);
        }
        else
        {
            return Json("Date of Birth is invalid.", JsonRequestBehavior.AllowGet);
        }
        return Json(true, JsonRequestBehavior.AllowGet);
    }
