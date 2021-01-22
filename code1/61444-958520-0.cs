    public void AddTaskToTree(TreeNodeCollection nodes, Task aTask)
    {
        TreeNode taskNode = nodes.Add(aTask.Name);
        foreach (Task subTask in aTask.Subtasks)
        {
            AddTaskToTree(taskNode.Nodes, subTask);
        }
    }
