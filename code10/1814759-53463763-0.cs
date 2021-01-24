    public void StartTasts(int n)
    {
        for (int i = 0; i < n; i++)
            queueList.Add(new Queue<string>());
        List<Task> tsk = new List<Task>();
        for (int TaskGroup = 0; TaskGroup < 10; TaskGroup++)
        {   //10 groups of task
            //each group has 'n' tasks working in parallel
            for (int i = 0; i < n; i++)
            {
                int k = j; // i would work here too and give you the same results.
                
                tsk.Add(Task.Factory.StartNew(() =>
                {
                    DoWork(k % n);
                }));
                j++;
            }
            //waiting for each task group to finish
            foreach (Task t in tsk)
                t.Wait();
            //after they all finished working with the queues, clear queues
            //making them ready for the nest task group
            foreach (Queue<string> q in queueList)
                q.Clear();
        }
    }
