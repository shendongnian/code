    private void Remove(ref Node n, int e)
        {
            if (n == null)
                return;
            if (e > n.Element) {
                if (e == n.Right.Element)
                    n.Right = null;
                else
                    Remove(ref n.Right, e);
            } else {
                if (e == n.Left.Element)
                    n.Left = null;
                else
                    Remove(ref n.Left, e);
            }
        }
