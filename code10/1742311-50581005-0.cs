    // pseudo code
    var parameter = new QueryHistoryParameters();
    parameter.RecursionType = RecursionType.Full;
    parameter.IncludeChanges = true;
    // set other members to potentially filter out unneeded stuff
    // especially, say, "VersionStart" / "VersionEnd".
    var result = workspace.VersionControlServer.QueryHistory(parameter);
    foreach (var entry in result)
    {
         // Compare "entry.ChangesetId" with the ID of the changeset you're looking for.
    }
