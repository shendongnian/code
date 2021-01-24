    public void RemoveNonRec(int value)
    {
        ref TreeNode node = ref this.Root;
        while (node != null)
        {
            if (value < node.Value)
            {
                node = ref node.Left;
            }
            else if (value > node.Value)
            {
                node = ref node.Right;
            }
            else
            {
                Remove(value, ref node);
                break;
            }
        }
    }
