    public void AddTaskToTree(TreeNodeCollection nodes, Task aTask)
    {
        TreeNode taskNode = New TreeNode(aTask.Name);
        nodes.Add(taskNode);
        foreach (Task subTask in aTask.Subtasks)
        {
            AddTaskToTree(taskNode.Nodes, subTask);
        }
    }
