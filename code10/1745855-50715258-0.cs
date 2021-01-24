            var emailString = "me@test.com;you@test.com";
            string[] emails = emailString.Split(';');
            string[] emailsFromSQL = new string[3];
            emailsFromSQL[0] = "everyone@test.com";
            emailsFromSQL[1] = "everyone2@test.com";
            emailsFromSQL[2] = "everyone2@test.com";
            //No Duplicates
            var combined = emails.Union(emailsFromSQL).ToArray();
            //Duplicates
            var allCombined = emails.Concat(emailsFromSQL).ToArray();
