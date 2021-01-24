    private Task<ReplyData>[] InitiateServerCalls(List<ServerData> replicasList, XuLiskovRequest request, CancellationToken cancellationToken)
    {
        int replicasCount = replicasList.Count;
        Task<ReplyData>[] tasksArray = new Task<ReplyData>[replicasCount];
        try
        {
            for (int ridx = 0; ridx < replicasCount; ridx++)
            {
                Thread.Sleep(250);
                ServerData serverData = replicasList[ridx];
                RequestData requestData = request.RequestData;
                tasksArray[ridx] = new Task<ReplyData>(() => CallServer(serverData, requestData, cancellationToken), cancellationToken);
                tasksArray[ridx].Start();
            }
        }
        catch (RemotingException) { RequestViewChange(); }
        return tasksArray;
    }
