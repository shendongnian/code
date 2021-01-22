            Control[] foundControls = null;
            // Find control with ID="BulletedList1".
            foundControls = FilterControls(Page,
                c => c.ID != null && c.ID.StartsWith("BulletedList1"));
            // Find all controls that start with ID="Panel*
            foundControls = FilterControls(Page,
                c => c.ID != null && c.ID.StartsWith("Panel"));
            // Find all table cells.
            foundControls = FilterControls(Page,
                c => c is TableCell);
            Response.Write(foundControls.Length); // 0 if none found.
