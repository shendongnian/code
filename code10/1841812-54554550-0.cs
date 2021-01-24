        private delegate void StatusMessage();
        /// <summary>
        ///     Simple methods for setting active cube list before connecting
        /// </summary>
        private void SetDefaultNode()
        {
            if (this.ActiveCubeStatus.InvokeRequired)
            {
                StatusMessage d = new StatusMessage(SetDefaultNodeDirect);
                this.Invoke(d);
            }
            else
            {
                SetDefaultNodeDirect();
            }
        }
        /// <summary>
        ///     Simple methods for setting active cube list before connecting
        /// </summary>
        private void SetDefaultNodeDirect()
        {
            //clears treeveiw
            ClearActiveCubes();
            //create default inactive node
            TreeNode nodeDefault = new TreeNode();
            nodeDefault.Name = "Waiting";
            nodeDefault.Text = "Waiting on connection...";
            this.ActiveCubeStatus.Nodes.Add(nodeDefault);
            nodeDefault = null;
        }
