        private delegate void TextUpdateHandler(string updatedText);
        private void UpdateServerStatuses(string statuses)
        {
            if (this.InvokeRequired)
            {
                TextUpdateHandler update = new TextUpdateHandler(this.UpdateServerStatuses);
                this.BeginInvoke(update, statuses);
            }
            else
            {
                // load textbox here
            }
        }
