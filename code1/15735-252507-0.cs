    void AddLogMessage(String message)
    {
        list.Items.Add(message);
        // DO: Append message to file as needed
        // Clip the list
        if (list.count > ListMaxSize)
        {            
            list.Items.RemoveRange(0, list.Count - listMinSize);
        }
        
        // DO: Focus the last item on the list
    }
