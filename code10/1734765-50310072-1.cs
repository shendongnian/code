    public void RemoveNonRec(int value)
    {
        ref TreeNode node = ref this.Root;
        while (node != null)
        {
            if (value < node.Value)
            {
                node = ref node.Left;      //add ref here
            }
            else if (value > node.Value)
            {
                node = ref node.Right;     //and here
            }
            else
            {
                Remove(value, ref node);
                break;
            }
        }
    }
