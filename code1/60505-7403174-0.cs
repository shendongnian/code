                // Stop our screen flickering.
            chSplitContainer.Panel2.SuspendLayout();
            // Make the bound fields visible or the binding doesn't work.
            tbxValueCr.Visible = true;
            tbxValueDb.Visible = true;
            // Update the fields here.
            <DO STUFF>
            // Restore settings to how they were, so you don't know we're here.
            tbxValueCr.Visible = false;
            tbxValueDb.Visible = false;
            chSplitContainer.Panel2.ResumeLayout();
