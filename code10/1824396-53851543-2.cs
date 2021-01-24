        /// <summary>
        /// Method called on button click.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender of the event.</param>
        /// <param name="e">The Routed event arguments <see cref="RoutedEventArgs"/>.</param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // string cmdUrl = txtCommandeUrl.Text;
            
            // i want to use cmdUrl in other class.cs
            OtherClass.CmdUrl = txtCommandeUrl.Text;
        }
