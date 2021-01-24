     private Guid _contactId;
        private Guid _userId;
    // Create the 'From:' activity party for the email
                    ActivityParty fromParty = new ActivityParty
                    {
                        PartyId = new EntityReference(SystemUser.EntityLogicalName, _userId)
                    };
                    // Create the 'To:' activity party for the email
                    ActivityParty toParty = new ActivityParty
                    {
                        PartyId = new EntityReference(Contact.EntityLogicalName, _contactId)
                    };
     To = new ActivityParty[] { toParty },
     From = new ActivityParty[] { fromParty },
