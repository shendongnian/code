        /// <summary>
        /// Handle the ListBox's SelectedValueChanged event, revert the selection if there are too many selected
        /// </summary>
        /// <param name="sender">the sending object</param>
        /// <param name="e">the event args</param>
        void ChildSelectionChanged(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            //If the number of selected items is greater than the number the user is allowed to select
            if ((this.MaxSelection != null) && (listBox.SelectedItems.Count > this.MaxSelection))
            {
                //Prevent this method from running while reverting the selection
                listBox.SelectedIndexChanged -= ChildSelectionChanged;
                //Revert the selection to the previously stored selection
                try
                {
                    for (int index = 0; index < listBox.Items.Count; index++)
                    {
                        if (listBox.SelectedIndices.Contains(index) && !this.previousSelection.Contains(index))
                        {
                            listBox.SetSelected(index, false);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                }
                catch (InvalidOperationException ex)
                {
                }
                finally
                {
                    //Re-enable this method as an event handler for the selection change event
                    listBox.SelectedIndexChanged += ChildSelectionChanged;
                }
            }
            else
            {
                RaiseSelectionChangedEvent();
            }
        }
        /// <summary>
        /// Handle the ListBox's MouseUp event, store the selection state.
        /// </summary>
        /// <param name="sender">the sending object</param>
        /// <param name="e">the event args</param>
        /// <remarks>This method saves the state of selection of the list box into a class member.
        /// This is used by the SelectedValueChanged handler such that when the user selects more 
        /// items than they are allowed to, it will revert the selection to the state saved here 
        /// in this MouseUp handler, which is the state of the selection at the end of the previous
        /// mouse click.  
        /// We have to use the MouseUp event since:
        /// a) the SelectedValueChanged event is called multiple times when a Shift-click is made;
        /// the first time it fires the item that was Shift-clicked is selected, the next time it
        /// fires, the rest of the items intended by the Shift-click are selected.  Thus using the
        /// SelectedValueChanged handler to store the selection state would fail in the following
        /// scenario:
        ///   i)   the user is allowed to select 2 items max
        ///   ii)  the user clicks Line1
        ///   iii) the SelectedValueChanged fires, the max has not been exceeded, selection stored
        ///        let's call it Selection_A which contains Line1
        ///   iii) the user Shift-clicks and item 2 lines down from the first selection called Line3
        ///   iv)  the SelectedValueChanged fires, the selection shows that only Line1 and Line3 are
        ///        selected, hence the max has not been exceeded, selection stored let's call it 
        ///        Selection_B which contains Line1, Line3
        ///   v)   the SelectedValueChanged fires again, this time Line1, Line2, and Line3 are selected,
        ///        hence the max has been exceeded so we revert to the previously stored selection
        ///        which is Selection_B, what we wanted was to revert to Selection_A
        /// b) the MouseDown event fires after the first SelectedValueChanged event, hence saving the 
        /// state in MouseDown also stores the state at the wrong time.</remarks>
        private void valuesListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.MaxSelection == null)
            {
                return;
            }
            ListBox listBox = sender as ListBox;
            //Store the current selection
            this.previousSelection.Clear();
            foreach (int selectedIndex in listBox.SelectedIndices)
            {
                this.previousSelection.Add(selectedIndex);
            }
        }
