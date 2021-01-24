    void Update () {
        // We refill the list if it is empty
        if(needToDisplayMessages.Count == 0)
            needToDisplayMessages.AddRange(base_messages);
        // Choose a random number topped by the count of messages still to be displayed
        int index = rnd.Next(0, needToDisplayMessages.Count);
        string message = needToDisplayMessages[index];
        ..... display the message someway .....
        // Remove the message from the list
        needToDisplayMessages.RemoveAt(index);
    }
