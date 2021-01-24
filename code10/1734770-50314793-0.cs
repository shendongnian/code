    public void RemoveNonRec(int value)
    {
        TreeNode node = Root;
        while (node != null)
        {
            if (value < node.Value)
            {
                if (node.Left != null && node.Left.Value == value)
                {
                    Remove(value, ref node.Left);
                    break;
                }
                node = node.Left;
            }
            else if (value > node.Value)
            {
                if (node.Right != null && node.Right.Value == value)
                {
                    Remove(value, ref node.Right);
                    break;
                }
                node = node.Right;
            }
            else
            {
                Remove(value, ref Root);
                break;
            }
        }
    }
