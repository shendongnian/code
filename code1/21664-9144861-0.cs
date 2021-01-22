    public partial class EnhancedCheckedListBox : CheckedListBox
    {
        /// <summary>Overrides the OnDrawItem for the CheckedListBox so that we can customize how the items are drawn.</summary>
        /// <param name="e">The System.Windows.Forms.DrawItemEventArgs object with the details</param>
        /// <remarks>A CheckedListBox can only have one item selected at a time and it's always the item in focus.
        /// So, don't draw an item as selected since the selection colors are hideous.  
        /// Just use the focus rect to indicate the selected item.</remarks>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Color foreColor = this.ForeColor;
            Color backColor = this.BackColor;
            DrawItemState s2 = e.State;
            //If the item is in focus, then it should always have the focus rect.
            //Sometimes it comes in with Focus and NoFocusRect.
            //This is annoying and the user can't tell where their focus is, so give it the rect.
            if ((s2 & DrawItemState.Focus) == DrawItemState.Focus)
            {
                s2 &= ~DrawItemState.NoFocusRect;
            }
            //Turn off the selected state.  Note that the color has to be overridden as well, but I just did that for all drawing since I want them to match.
            if ((s2 & DrawItemState.Selected) == DrawItemState.Selected)
            {
                s2 &= ~DrawItemState.Selected;
                
            }
            //Console.WriteLine("Draw " + e.Bounds + e.State + " --> " + s2);
            //Compile the new drawing args and let the base draw the item.
            DrawItemEventArgs e2 = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, s2, foreColor, backColor);
            base.OnDrawItem(e2);
        }
    }
