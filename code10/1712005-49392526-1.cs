    [AjaxErrorHandling]
    [HttpPost]
    public async Task SyncDriverToVistracks(int DriverID)
    {
        Activity.Current.AddTag("DriverID", DriverID.ToString());
        Activity.Current.AddTag("UserID", User.Identity.Name);
    
        try
        {
            if ([condition])
            {
                // some actions here
    
                try
                {
                    // If below call is HTTP then no need to use StartOperation
                    using (telemetryClient.StartOperation<DependencyTelemetry>("AddNewDriverToVistrackAsync"))
                    {
                        driver.VistrackId = await _vistracksService.AddNewDriverToVistrackAsync(domain);
                    }
    
                    // If below call is HTTP then no need to use StartOperation
                    using (telemetryClient.StartOperation<DependencyTelemetry>("SaveChanges"))
                    {
                        await db.SaveChangesAsync();
                    }
                }
                catch (VistracksApiException api_ex)
                {
                    // external service throws exception type VistracksApiException 
                    throw new AjaxException("vistracksApiClient", api_ex.Response.Message);
                }
                catch (VistracksApiCommonException common_ex)
                {
                    // external service throws exception type VistracksApiCommonException 
                    throw new AjaxException("vistracksApiServer", "3MD HOS server is not available");
                }
                catch (Exception ex)
                {
                    // something wrong at all
                    throw new AjaxException("General", ex.Message);
                }
            }
            else
            {
                // condition is not valid
                throw new AjaxException("General", "AccountId is not found");
            }
        }
        catch (Exception ex)
        {
            // Upcoming 2.6 AI SDK will track exceptions for MVC apps automatically.
            telemetryClient.TrackException(ex);
            throw;
        }
    }
