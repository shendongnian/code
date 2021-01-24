    private void RemoveRec(int value, ref TreeNode node)
    {
        if (node != null)
        {
            if (value < node.Value)
            {
                RemoveRec(value, ref node.GetLeft());
            }
            else if (value > node.Value)
            {
                RemoveRec(value, ref node.GetRight());
            }
            else
            {
                Remove(value, ref node);
            }
        }
    }
    public void RemoveNonRec(int value)
    {
        if(value == Root.Value)
        {
            Remove(value, ref Root);
        }
        else
        {
            TreeNode node = Root;
            while (node != null)
            {
                if (value < node.Value)
                {
                    node = node.GetLeft();
                }
                else if (value > node.Value)
                {
                    node = node.GetRight();
                }
                else
                {
                    Remove(value, ref node);
                    break;
                }
            }
        }
    }
    private void Remove(int value, ref TreeNode node)
    {
        if (node != null)
        {
            if (node.Counter > 1)
            {
                --node.Counter;
                Console.WriteLine("Deleted element: {0}, elements in the node: {1}", node.Value, node.Counter);
            }
            else
            {
                int vMes = node.Value;
                ref TreeNode left = ref node.GetLeft();
                ref TreeNode right = ref node.GetRight();
                if (left == null && right == null)
                {
                    node = null;
                }
                else if (left != null && right == null)
                {
                    node = left;
                }
                else if (left == null && right != null)
                {
                    node = right;
                }
                else
                {
                    if (node.GetRight().GetLeft() == null)
                    {
                        node.GetRight().GetLeft() = left;
                        node = right;
                    }
                    else
                    {
                        TreeNode p = right;
                        ref TreeNode leftLeft = ref p.GetLeft().GetLeft();
                        while (leftLeft != null)
                            p = p.GetLeft();
                        ref TreeNode q = ref p.GetLeft();
                        p.GetLeft() = q.GetRight();
                        q.GetLeft() = node.GetLeft();
                        q.GetRight() = node.GetRight();
                        node = q;
                    }
                }
                Console.WriteLine("Deleted node: {0}", vMes);
            }
        }
    }
