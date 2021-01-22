            try
            {
                using (DashboardService.DashboardServiceClient svc = new Dashboard_WPF_Test.DashboardService.DashboardServiceClient())
                {
                    svc.GetChart(0);
                }
            }
            catch (System.ServiceModel.EndpointNotFoundException ex)
            {
                //handle endpoint not found exception here (I was never able to catch this type of exception using the using statement block)
            }
            catch (Exception ex)
            {
                //general exception handler
            }
