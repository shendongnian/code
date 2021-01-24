            PhoneType a = new PhoneType()
            {
                phoneType = "cell"
            };
            a.Contacts.Add(new Contact()
            {
                fName = "Andra",
                lName = "Avram",
                phoneNumber = "438-881-5659"
            });
            context.PhoneTypes.Add(a);
            context.SaveChanges();
            base.Seed(context);
