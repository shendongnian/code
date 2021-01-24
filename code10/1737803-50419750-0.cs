            //define signer            
            TemplateRole signer1 = new TemplateRole();
            signer1.Name = "Example User";
            signer1.Email = "user@example.com";
            signer1.RoleName = "Signer 1";
            //populate envelope object
            EnvelopeDefinition envelopeDefinition = new EnvelopeDefinition();
            envelopeDefinition.TemplateId = "xxx-yyy-zzz"; // Replace with template ID
            envelopeDefinition.Status = "created"; //generates draft instead of immediately sending
            //create text tab object
            Text text1 = new DocuSign.eSign.Model.Text();
            text1.TabLabel = "Text1";
            text1.Value = "Example Text";
            //apply tab to signer
            signer1.Tabs = new Tabs();
            signer1.Tabs.TextTabs = new List<DocuSign.eSign.Model.Text>();
            signer1.Tabs.TextTabs.Add(text1);
            //apply signer 
            List<TemplateRole> templateroles = new List<TemplateRole>() { signer1 };
            envelopeDefinition.TemplateRoles = templateroles;
            
            //create EnvelopesApi object
            EnvelopesApi template = new EnvelopesApi(apiClient.Configuration);
            //execute envelope generation
            EnvelopeSummary response = template.CreateEnvelope(accountId, envelopeDefinition);
