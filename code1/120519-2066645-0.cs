    /// <summary>
            /// Displays the alert.
            /// </summary>
            /// <param name="message">The message to display.</param>
            protected virtual void DisplayAlert(string message)
            {
                ClientScript.RegisterStartupScript(
                                GetType(),
                                Guid.NewGuid().ToString(),
                                string.Format("alert('{0}');", message.Replace("'", @"\'")),
                                true
                            );
            }
    
            /// <summary>
            /// Finds the control recursive.
            /// </summary>
            /// <param name="id">The id.</param>
            /// <returns>control</returns>
            protected virtual Control FindControlRecursive(string id)
            {
                return FindControlRecursive(id, this);
            }
    
            /// <summary>
            /// Finds the control recursive.
            /// </summary>
            /// <param name="id">The id.</param>
            /// <param name="parent">The parent.</param>
            /// <returns>control</returns>
            protected virtual Control FindControlRecursive(string id, Control parent)
            {
                if (string.Compare(parent.ID, id, true) == 0)
                    return parent;
    
                foreach (Control child in parent.Controls)
                {
                    Control match = FindControlRecursive(id, child);
    
                    if (match != null)
                        return match;
                }
    
                return null;
            }
