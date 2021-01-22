            DashboardService.DashboardServiceClient svc = new Dashboard_WPF_Test.DashboardService.DashboardServiceClient();
            try
            {
                svc.GetChart(0);
            }
            catch (System.ServiceModel.EndpointNotFoundException ex)
            {
                //handle endpoint not found exception here
            }
            catch (Exception ex)
            {
                //general exception handler
            }
            finally
            {
                if (!svc.State.Equals(System.ServiceModel.CommunicationState.Faulted) && svc.State.Equals(System.ServiceModel.CommunicationState.Opened))
                svc.Close();
            }
