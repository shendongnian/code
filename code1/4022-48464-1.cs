        class BinarySearchTree<T> where T : IComparable<T>
        {
            private BSTNode<T> _root = null;
            private int _count = 0;
    
            public virtual void Clear()
            {
                _root = null;
                _count = 0;
            }
    
            public virtual int Count
            {
                get { return _count; }
            }
    
            public virtual void Add(T value)
            {
                BSTNode<T> newNode = new BSTNode<T>();
                int compareResult = 0;
    
                newNode.Value = value;
    
                if (_root == null)
                {
                    this._count++;
                    _root = newNode;
                }
                else
                {
                    BSTNode<T> current = _root;
                    BSTNode<T> parent = null;
    
                    while (current != null)
                    {
                        compareResult = current.Value.CompareTo(newNode.Value);
    
                        if (compareResult > 0)
                        {
                            parent = current;
                            current = current.Left;
                        }
                        else if (compareResult < 0)
                        {
                            parent = current;
                            current = current.Right;
                        }
                        else
                        {
                            // Node already exists
                            throw new ArgumentException("Duplicate nodes are not allowed.");
                        }
                    }
    
                    this._count++;
    
                    compareResult = parent.Value.CompareTo(newNode.Value);
                    if (compareResult > 0)
                    {
                        parent.Left = newNode;
                    }
                    else
                    {
                        parent.Right = newNode;
                    }
                }
            }
    
            public virtual BSTNode<T> FindByValue(T value)
            {
                BSTNode<T> current = this._root;
    
                if (current == null)
                    return null;   // Tree is empty.
                else
                {
                    while (current != null)
                    {
                        int result = current.Value.CompareTo(value);
                        if (result == 0)
                        {
                            // Found the corrent Node.
                            return current;
                        }
                        else if (result > 0)
                        {
                            current = current.Left;
                        }
                        else
                        {
                            current = current.Right;
                        }
                    }
    
                    return null;
                }
            }
    
            public virtual void Delete(T value)
            {
    
                BSTNode<T> current = this._root;
                BSTNode<T> parent = null;
    
                int result = current.Value.CompareTo(value);
    
                while (result != 0 && current != null)
                {
                    if (result > 0)
                    {
                        parent = current;
                        current = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent = current;
                        current = current.Right;
                    }
    
                    result = current.Value.CompareTo(value);
                }
    
                if (current == null)
                    throw new ArgumentException("Cannot find item to delete.");
    
                
    
                if (current.Right == null)
                {
                    if (parent == null)
                        this._root = current.Left;
                    else
                    {
                        result = parent.Value.CompareTo(current.Value);
                        if (result > 0)
                        {
                            parent.Left = current.Left;
                        }
                        else if (result < 0)
                        {
                            parent.Right = current.Left;
                        }
                    }
                }
                else if (current.Right.Left == null)
                {
                    if (parent == null)
                        this._root = current.Right;
                    else
                    {
                        result = parent.Value.CompareTo(current.Value);
                        if (result > 0)
                        {
                            parent.Left = current.Right;
                        }
                        else if (result < 0)
                        {
                            parent.Right = current.Right;
                        }
                    }
                }
                else
                {
    
                    BSTNode<T> furthestLeft = current.Right.Left;
                    BSTNode<T> furthestLeftParent = current.Right;
    
                    while (furthestLeft.Left != null)
                    {
                        furthestLeftParent = furthestLeft;
                        furthestLeft = furthestLeft.Left;
                    }
    
                    furthestLeftParent.Left = furthestLeft.Right;
    
                    furthestLeft.Left = current.Left;
                    furthestLeft.Right = current.Right;
    
                    if (parent != null)
                    {
                        result = parent.Value.CompareTo(current.Value);
                        if (result > 0)
                        {
                            parent.Left = furthestLeft;
                        }
                        else if (result < 0)
                        {
                            parent.Right = furthestLeft;
                        }
                    }
                    else
                    {
                        this._root = furthestLeft;
                    }
                }
    
                this._count--;
            }
        }
    }
