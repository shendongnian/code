        private void CheckAllProperties()
        {
            if (this.AllPropertiesNotNull())
            {
                AllPropertiesSet?.Invoke(this, new EventArgs());
            }
        }
