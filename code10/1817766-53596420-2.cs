        /// <summary>
        /// Method that updates a property representing how long the port module has been booted for.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_Tick(object sender, EventArgs e)
        {
            this.TimePortModuleIsUp = new DateTime((DateTime.Now - this.ModuleBootTime).Ticks).ToString("HH:mm:ss");
        }
