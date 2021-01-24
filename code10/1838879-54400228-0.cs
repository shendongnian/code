    public void Save(BaseInfo baseInfo, bool doFireSaveEvent)
    {
        var allowsUpdateEvents = DocumentEvents.Update.Allow;
        DocumentEvents.Update.Allow = doFireSaveEvent;
        try
        {
            baseInfo.Update();
        }
        catch (Exception e)
        {
            EventLogProvider.LogEvent(
                "E",
                $"{nameof(TreeNodeRepository)}.{ nameof(TreeNodeRepository.Save)}",
                "TREENODE_CAN_NOT_BE_SAVED",
                e.Message);
        }
        finally
        {
            DocumentEvents.Update.Allow = allowsUpdateEvents;
        }
    }
