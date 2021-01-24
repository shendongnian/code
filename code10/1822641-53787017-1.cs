            var Approver_Recs = new List<Action_Record>();
            Action_Record o = new Action_Record() { Type = "Finance" , Action = "Reject" };
            Approver_Recs.Add(o);
            Action_Record o2 = new Action_Record() { Type = "Finance" , Action = "Approve" };
            ActionRecordValidator validator = new ActionRecordValidator();
            Approver_Recs.Add(o2);
            ValidationResult results = validator.Validate(Approver_Recs);
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
 
 
