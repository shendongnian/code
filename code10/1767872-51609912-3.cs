    private void MoveNext()
    {
        int num = <>1__state;
        try
        {
            TaskAwaiter awaiter;
            if (num != 0)
            {
                if (amount == 1)
                {
                    throw new ArgumentException();
                }
                awaiter = Task.Delay(1).GetAwaiter();
                if (!awaiter.IsCompleted)
                {
                    // Unimportant
                }
            }
            else
            {
                // Unimportant
            }
        }
        catch (Exception exception)
        {
            <>1__state = -2;
            <>t__builder.SetException(exception); // Add exception to the task.
            return;
        }
        <>1__state = -2;
        <>t__builder.SetResult();
    }
