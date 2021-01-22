    volatile bool cancelDrag;
    protected override void OnMouseUp(MouseEventArgs e)
    {
        cancelDrag = true;
        base.OnMouseUp(e);
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        cancelDrag = false;
        ThreadPool.QueueUserWorkItem(delegate
        {
            Thread.Sleep(250);
            if (!cancelDrag)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    if (!cancelDrag)
                    {
                        // your code here...
                        var sel = this.SelectedRows;
                        if (sel.Count > 0)
                        {
                            this.DoDragDrop("test", DragDropEffects.All);
                        }
                    }
                });
            }
        });
    }
