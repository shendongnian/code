    TfsTeamProjectCollection teamCollection;
                ITestManagementService service;
                ITestManagementTeamProject project;
                var picker = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false);
                picker.ShowDialog();
                if (picker.SelectedTeamProjectCollection != null && picker.SelectedProjects != null)
                {
                    teamCollection = picker.SelectedTeamProjectCollection;
                    service = teamCollection.GetService<ITestManagementService>();
                    project = service.GetTeamProject(picker.SelectedProjects.First().Name);
                }
                else
                {
                    return;
                }
             
                var result = project.TestResults.ByTestId({test case id}).Last();
