    private async void TCheckLockedKeys_Tick(object sender, EventArgs e) {
        try {
            //...
            if (statusesChanged) {
                // update all bools
                bool1 = ...;
                bool2 = ...;
                bool3 = ...;
                // build int[] from bool values
                int[] statuses = new int[] { Convert.ToInt32(bool1), Convert.ToInt32(bool2), Convert.ToInt32(bool3) };
                // update UWP sibling
                await SendToUWPVoidAsync(statuses);
            }
            // ask for new settings
            await SendToUWPVoidAsync("request");
            
        }catch {
            //...handle error appropriately
        }
    }
    
