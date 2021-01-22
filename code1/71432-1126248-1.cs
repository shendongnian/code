            using (IEnumerator<T> e = list.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    T o = (MyClass)e.Current;
                    if (row.value == value)
                    {
                        // Do something
                    }
                }
            }
