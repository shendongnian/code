        private string LogTelemetry(Exception ex)
        {
            var telemetryClient = new TelemetryClient();
            var telemetry = new ExceptionTelemetry(ex);
            var operationId = HttpContext.Current.Items["RequestIdentity"].ToString();
            telemetryClient.Context.Operation.Id = operationId;
            telemetryClient.TrackException(telemetry);
            return operationId;
        }
