    private Node Remove(ref Node n, int e)
        {
            if (n == null)
                return null;
            if (e > n.Element) {
                if (e == n.Right.Element) {
                    Node res = n.Right;
                    n.Right = null;
                    return res;
                } else
                    return Remove(ref n.Right, e);
            } else {
                if (e == n.Left.Element) {
                    Node res = n.Left;
                    n.Left = null;
                    return res;
                } else
                    return Remove(ref n.Left, e);
            }
        }
