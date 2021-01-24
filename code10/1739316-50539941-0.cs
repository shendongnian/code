        private void RefreshOnMove()
        {
            // invalidate the old rect (+ size of red box)
            var rc = oldRcSelect;
            rc.Inflate(3, 3);
            Invalidate(rc);
            // invalidate the new rect (+ size of red box)
            // note you can almost omit this second one, but if you move the mouse really fast, you'll see some red box not fully displayed
            // but the benefit is small, something like a 3 x width/height rectangle
            rc = rcSelect;
            rc.Inflate(3, 3);
            Invalidate(rc);
            // each time you call invalidate, you just accumulate a change
            // to the change region, nothing actually changes on the screen
            // now, ask Windows to process the combination of changes
            Update();
        }
