    if (ApplicationDeployment.IsNetworkDeployed)
            {
                if (ApplicationDeployment.CurrentDeployment.CurrentVersion != ApplicationDeployment.CurrentDeployment.UpdatedVersion)
                {
                    Application.ExitThread();
                    Application.Restart();
                }
            }
