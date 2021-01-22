    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        
        this.Visible = (queue.Count > 0);
        if (this.Visible)
        {
            while (queue.Count > 0)
            {
                MessageItem message = queue.Dequeue();
                this.Controls.Add(new LiteralControl(message.ToString()));
            }
        }
    }
