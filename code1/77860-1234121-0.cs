            public static IEnumerable<T> FindChildControls<T>(Control parentControl,
            Predicate<Control> predicate) where T : Control
            {
                Queue<Control> q = new Queue<Control>();
                foreach (Control item in parentControl.Controls)
                {
                    q.Enqueue(item);
                }
                while (q.Count > 0)
                {
                    Control item = q.Dequeue();
                    if (predicate(item))
                        yield return (T)item;
                    foreach (Control child in item.Controls)
                    {
                        q.Enqueue(child);
                    }
                }
            }
