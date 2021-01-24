    private ActionBlock<OperationType> actionBlock;
    public void OnTreeViewExpand()
    {
        //Re-initialize the actionblock for a new set of operations
        actionBlock = new ActionBlock<OperationType>(async _operationType =>
        {
            logManager.WriteLog($"Library : Sending the operation to connector service : item {itemId}, the name of the item is {itemPresence.ItemName}", System.Threading.Thread.CurrentThread.ManagedThreadId.ToString(), LogManagement.LogLevel.Information);
            await connectorService.EnqueueConnectorOperations(operationType, ci, itemId, Settings.Default.ProjectLocalPath + @"\" + ci.ID.ToString(), ConnectorID, Settings.Default.DisplayLanguage, Settings.Default.ProjectLocalPath, itemPresence).ConfigureAwait(false);
        }, new ExecutionDataflowBlockOptions
        {
            MaxDegreeOfParallelism = 1,
            CancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(5)).Token,
        });
    }
    private async Task<bool> UpdateSubItemsStatus()
    {
        foreach (var item in connectorsMenuItems)
        {
            await parent.Library.EnqueueConnectorOperations(Connectors.service.OperationType.CheckPresence, parent.CI, AssetId, item.ConnectorID, parent.ConnectorInterfaces.Single(c => c.ItemId == AssetId).ItemsConnectorPresence.Single(i => i.ConnectorId == item.ConnectorID));
        }
        //All items sent, signal completion
        actionBlock.Complete();
        await actionBlock.Completion;
        return true;
    }
    public Task EnqueueConnectorOperations(OperationType operationType, ConfigurationItem ci, Guid itemId, Guid ConnectorID, ItemConnectorPresence itemPresence)
    {
        logManager.WriteLog($"Library : Received connector operation for item {itemId}, the name of the item is {itemPresence.ItemName}", System.Threading.Thread.CurrentThread.ManagedThreadId.ToString(), LogManagement.LogLevel.Information);
        //Set requestor UI item in working state in the UI
        if (ci.CIType == EnumCIType.Application)
        {
            LibraryItems.Single(l => l.CI.ID == ci.ID).DeployableAssetMenuItems.Single(d => d.AssetId == itemId).ConnectorsMenuItems.Single(c => c.ConnectorID == ConnectorID).IsWorking = true;
            LibraryItems.Single(l => l.CI.ID == ci.ID).DeployableAssetMenuItems.Single(d => d.AssetId == itemId).ConnectorsMenuItems.Single(c => c.ConnectorID == ConnectorID).Status = LibraryItemState.UpdatingStatus;
            LibraryItems.Single(l => l.CI.ID == ci.ID).DeployableAssetMenuItems.Single(d => d.AssetId == itemId).ConnectorsMenuItems.Single(c => c.ConnectorID == ConnectorID).StatusString = "Checking Presence";
        }
        return actionBlock.SendAsync(operationType);
    }
