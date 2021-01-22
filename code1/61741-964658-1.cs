    foreach (Frobozz bar in foo) {
        Baz result = new Baz(kDefaultConfiguration);
        try {
            Baz remoteResult = boo.GetConfiguration();
        }
        catch (RemoteConnectionException) {
            continue;
        }
        result.Merge(remoteResult);
        ReportResult(result);
    }
