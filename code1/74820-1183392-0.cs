    static void CascadeListBoxEvent(Control parent, EventHandler handler)
    {
        Queue<Control> queue = new Queue<Control>();
        queue.Enqueue(parent);
        while (queue.Count > 0)
        {
            Control c = queue.Dequeue();
            ListBox lb = c as ListBox;
            if (lb != null)
            {
                lb.SelectedIndexChanged += handler;
            }
            foreach (Control child in c.Controls)
            {
                queue.Enqueue(child);
            }
        }
    }
