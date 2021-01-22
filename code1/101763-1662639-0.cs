            Page newPage;
            if (App.ModeType == "Mode1"){ newPage = new MyClient.Pages.Mode1.Building(); }
            else if (App.ModeType == "Mode2") { newPage = new MyClient.Pages.Mode2.RiskQuestions(); }
            else { throw new NotImplementedException(); } ///Must be Mode3
                Organisations thisOrg = (Organisations)lvOrganisations.SelectedItem;
            App.selectedOrganisation = thisOrg;
            NavigationService.Navigate(newPage);
