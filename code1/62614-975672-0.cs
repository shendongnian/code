        private T FindParent<T>(DependencyObject item, Type StopAt) where T : class
        {
            if (item is T)
            {
                return item as T;
            }
            else
            {
                DependencyObject _parent = VisualTreeHelper.GetParent(item);
                if (_parent == null)
                {
                    return default(T);
                }
                else
                {
                    Type _type = _parent.GetType();
                    if (StopAt != null)
                    {
                        if ((_type.IsSubclassOf(StopAt) == true) || (_type == StopAt))
                        {
                            return null;
                        }
                    }
                    if ((_type.IsSubclassOf(typeof(T)) == true) || (_type == typeof(T)))
                    {
                        return _parent as T;
                    }
                    else
                    {
                        return FindParent<T>(_parent, StopAt);
                    }
                }
            }
        }
