            treeHasFocus = true;
            //base.OnGotFocus(e);
        }
        /// <summary>
        /// Alot easier to handle here (in Derived TreeView control then using all kinds of 
        ///     -= events to try to prevent.
        /// 
        /// This was the cleanest way I could find (prevent firing of AfterSelect)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)                
        {                                                               
            treeHasFocus = false;                                       
            //base.OnLostFocus(e);
        }
        /// <summary>
        /// -  Treeview Control defaults to selecting the first node (when gets focus)
        /// -  We do NOT want this - since would automatically Highlight the first node (select)
        /// -  treeHasFocus is NOT true for the first unwanted "automatic" selection of the first item
        /// -  Upon loosing Focus, the AfterSelect handler is never called.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnAfterSelect(TreeViewEventArgs e)      
        {                                                               
            if (treeHasFocus)                                           
                base.OnAfterSelect(e);                                   
            this.SelectedNode = null;                                   
        }
