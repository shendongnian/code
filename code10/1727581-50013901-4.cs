            ContextMenuStrip popUpGuest = new ContextMenuStrip();
            ToolStripTextBox guestMenuitem1 = new ToolStripTextBox();
            guestMenuitem1.Text = "Guest Option1";
            guestMenuitem1.Tag = contextMenuOptions.guestOption1; //tagging with enum
            guestMenuitem1.Click += Menuitem_Click;
            popUpGuest.Items.Add(guestMenuitem1);
            txtGuest.ContextMenuStrip = popUpGuest;
