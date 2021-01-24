    switch (targetViewModel)
                {
                    case "1":
                        CurrentViewModel = new ProjectViewModel();
                        break;
                    case "2":
                        CurrentViewModel = new ManageSkillsViewModel();
                        break;
                    default:
                        CurrentViewModel = null;
                        break;
                }
