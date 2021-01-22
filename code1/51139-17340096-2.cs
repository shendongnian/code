    class ComboListMatcher : ComboBox, IMessageFilter
    {
        private Control ComboParentForm; // Or use type "Form" 
        private ListBox listBoxChild;
        private int IgnoreTextChange;
        private bool MsgFilterActive = false;
    
        public ComboListMatcher()
        {
            // Set up all the events we need to handle
            TextChanged += ComboListMatcher_TextChanged;
            SelectionChangeCommitted += ComboListMatcher_SelectionChangeCommitted;
            LostFocus += ComboListMatcher_LostFocus;
            MouseDown += ComboListMatcher_MouseDown;
            HandleDestroyed += ComboListMatcher_HandleDestroyed;
        }
    
        void ComboListMatcher_HandleDestroyed(object sender, EventArgs e)
        {
            if (MsgFilterActive)
                Application.RemoveMessageFilter(this);
        }
    
        ~ComboListMatcher()
        {
        }
    
        private void ComboListMatcher_MouseDown(object sender, MouseEventArgs e)
        {
            HideTheList();
        }
    
        void ComboListMatcher_LostFocus(object sender, EventArgs e)
        {
            if (listBoxChild != null && !listBoxChild.Focused)
                HideTheList();
        }
    
        void ComboListMatcher_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IgnoreTextChange++;
        }
    
        void InitListControl()
        {
            if (listBoxChild == null)
            {
                // Find parent - or keep going up until you find the parent form
                ComboParentForm = this.Parent;
    
                if (ComboParentForm != null)
                {
                    // Setup a messaage filter so we can listen to the keyboard
                    if (!MsgFilterActive)
                    {
                        Application.AddMessageFilter(this);
                        MsgFilterActive = true;
                    }
    
                    listBoxChild = listBoxChild = new ListBox();
                    listBoxChild.Visible = false;
                    listBoxChild.Click += listBox1_Click;
                    ComboParentForm.Controls.Add(listBoxChild);
                    ComboParentForm.Controls.SetChildIndex(listBoxChild, 0); // Put it at the front
                }
            }
        }
    
    
        void ComboListMatcher_TextChanged(object sender, EventArgs e)
        {
            if (IgnoreTextChange > 0)
            {
                IgnoreTextChange = 0;
                return;
            }
    
            InitListControl();
    
            if (listBoxChild == null)
                return;
    
            string SearchText = this.Text;
    
            listBoxChild.Items.Clear();
    
            // Don't show the list when nothing has been typed
            if (!string.IsNullOrEmpty(SearchText))
            {
                foreach (string Item in this.Items)
                {
                    if (Item != null && Item.Contains(SearchText, StringComparison.CurrentCultureIgnoreCase))
                        listBoxChild.Items.Add(Item);
                }
            }
    
            if (listBoxChild.Items.Count > 0)
            {
                Point PutItHere = new Point(this.Left, this.Bottom);
                Control TheControlToMove = this;
    
                PutItHere = this.Parent.PointToScreen(PutItHere);
    
                TheControlToMove = listBoxChild;
                PutItHere = ComboParentForm.PointToClient(PutItHere);
    
                TheControlToMove.Show();
                TheControlToMove.Left = PutItHere.X;
                TheControlToMove.Top = PutItHere.Y;
                TheControlToMove.Width = this.Width;
    
                int TotalItemHeight = listBoxChild.ItemHeight * (listBoxChild.Items.Count + 1);
                TheControlToMove.Height = Math.Min(ComboParentForm.ClientSize.Height - TheControlToMove.Top, TotalItemHeight);
            }
            else
                HideTheList();
        }
    
        /// <summary>
        /// Copy the selection from the list-box into the combo box
        /// </summary>
        private void CopySelection()
        {
            if (listBoxChild.SelectedItem != null)
            {
                this.SelectedItem = listBoxChild.SelectedItem;
                HideTheList();
                this.SelectAll();
            }
        }
    
        private void listBox1_Click(object sender, EventArgs e)
        {
            var ThisList = sender as ListBox;
    
            if (ThisList != null)
            {
                // Copy selection to the combo box
                CopySelection();
            }
        }
    
        private void HideTheList()
        {
            if (listBoxChild != null)
                listBoxChild.Hide();
        }
    
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x201) // Mouse click: WM_LBUTTONDOWN
            {
                var Pos = new Point((int)(m.LParam.ToInt32() & 0xFFFF), (int)(m.LParam.ToInt32() >> 16));
    
                var Ctrl = Control.FromHandle(m.HWnd);
                if (Ctrl != null)
                {
                    // Convert the point into our parent control's coordinates ...
                    Pos = ComboParentForm.PointToClient(Ctrl.PointToScreen(Pos));
    
                    // ... because we need to hide the list if user clicks on something other than the list-box
                    if (ComboParentForm != null)
                    {
                        if (listBoxChild != null &&
                            (Pos.X < listBoxChild.Left || Pos.X > listBoxChild.Right || Pos.Y < listBoxChild.Top || Pos.Y > listBoxChild.Bottom))
                        {
                            this.HideTheList();
                        }
                    }
                }
            }
            else if (m.Msg == 0x100) // WM_KEYDOWN
            {
                if (listBoxChild != null && listBoxChild.Visible)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case 0x1B: // Escape key
                            this.HideTheList();
                            return true;
    
                        case 0x26: // up key
                        case 0x28: // right key
                            // Change selection
                            int NewIx = listBoxChild.SelectedIndex + ((m.WParam.ToInt32() == 0x26) ? -1 : 1);
    
                            // Keep the index valid!
    						if (NewIx >= 0 && NewIx < listBoxChild.Items.Count)
	    						listBoxChild.SelectedIndex = NewIx;
                            return true;
    
                        case 0x0D: // return (use the currently selected item)
                            CopySelection();
                            return true;
                    }
                }
            }
    
            return false;
        }
    }
