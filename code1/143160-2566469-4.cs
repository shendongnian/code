    private void Remove(Node n, int e)
        {
            if (n == null)
                return;
            if (e > n.Element) {
                if (e == n.Right.Element)
                    n.Right = null;
                else
                    Remove(n.Right, e);
            } else {
                if (e == n.Left.Element)
                    n.Left = null;
                else
                    Remove(n.Left, e);
            }
        }
