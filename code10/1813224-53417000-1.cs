        protected override void OnActivated(EventArgs e)
        {
            if (this.GetType() != typeof(UpdateHint) && MainWindow.updateHint != null)
            {
                Log.t("Setting owner on update hint: " + this.GetType());
                MainWindow.updateHint.Owner = this;
            }
            base.OnActivated(e);
        }
    }
