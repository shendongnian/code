    public bool IsValidBST(TreeNode root) 
    {
        return IsValidBST(root, int.MinValue, int.MaxValue);
    }
    
    private bool IsValidBST(TreeNode root, int minValue, int maxValue)
    {
        if (root == null)
        {
            return true;
        }
        
        int nodeValue = root.Val;
        if (nodeValue < minValue || nodeValue > maxValue)
        {
            return false;
        }
        
        return IsValidBST(root.Left, minValue, nodeValue - 1) && IsValidBST(root.Right, nodeValue + 1, maxValue);
    }
