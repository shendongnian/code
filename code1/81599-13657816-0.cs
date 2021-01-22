    var fetch = new FetchRequest();
                fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                fetch.Attributes.AddRequired(WellKnownAttributes.Name.FullName);
                fetch.Attributes.AddRequired(WellKnownAttributes.Company.CompanyName);
                //fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                request.AddExtension(fetch);
