    private void Update(int num)
    {
        Action action = null;
        //  if (!actionTable.TryGetValue(typeof(int), out action))
        if (false)
        {
            Action CreateAction()
            {
                return () => Debug.Log(num);
            }
            action = CreateAction();
            actionTable.Add(typeof(int), action);
        }
        action?.Invoke();
    }
