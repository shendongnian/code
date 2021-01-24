    UpdateCheckInfo info = null;
            if (Directory.Exists(@"F:\..."))
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;
                    try
                    {
                        info = ad.CheckForDetailedUpdate();
                    }
                    catch { }
                    if (info.UpdateAvailable)
                    {
                        try
                        {
                            ad.Update();
                            Application.Restart();
                        }
                        catch { }
                    }
                }
            }
