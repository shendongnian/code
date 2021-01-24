    var retry = Policy
        .HandleResult<DescribeApplicationVersionsResponse>(x => x.ApplicationVersions[0]?.Status != ApplicationVersionStatus.Processed)
        .WaitAndRetryAsync(10, retryAttempt => TimeSpan.FromSeconds(1), onRetry: (describeResponse, timeSpan, context) => {
            Console.WriteLine($"Application version was '{describeResponse.Result.ApplicationVersions[0].Status}', retrying in {timeSpan}");
        });
    var fallback = Policy
        .HandleResult<DescribeApplicationVersionsResponse>(x => x.ApplicationVersions[0]?.Status != ApplicationVersionStatus.Processed) // Probably worth factoring the predicate out into a method so that it is only stated once.
        .FallbackAsync(async () => { throw new ReplacementException(); });
    var r = await fallback.WrapAsync(retry)
        .ExecuteAsync(() =>
       BeanstalkClient.DescribeApplicationVersionsAsync(describeApplicationVersionRequest)
    );
