    WinSDK.RECT parentRect = new WinSDK.RECT();
                WinSDK.RECT intersectRect = new WinSDK.RECT();
                
                Rectangle parentRectangle = new Rectangle();
                Rectangle intersectRectangle = new Rectangle();
                // Get the current Handle.
                IntPtr currentHandle = this.Handle;
                // Get next Parent Handle.
                IntPtr parentHandle = WinSDK.GetParent(this.Handle);
                // Get the Rect for the current Window.
                WinSDK.GetWindowRect(this.Handle, out intersectRect);
                // Load Current Window Rect into a System.Drawing.Rectangle
                intersectRectangle = new Rectangle(intersectRect.left, intersectRect.top, intersectRect.right - intersectRect.left, intersectRect.bottom - intersectRect.top );
                // Itterate through all parent windows and get the overlap of the visible areas to find out what's actually visible.
                while (parentHandle != IntPtr.Zero)
                {
                    // Get the Rect for the Parent Window.
                    WinSDK.GetWindowRect(parentHandle, out parentRect);
                    parentRectangle = new Rectangle(parentRect.left, parentRect.top, parentRect.right - parentRect.left, parentRect.bottom - parentRect.top);
                 
                    // Get the intersect between the current and parent window.
                    intersectRectangle.Intersect(parentRectangle);
                    // Set up for next loop.
                    currentHandle = parentHandle;
                    parentHandle = WinSDK.GetParent(currentHandle);
                }
                return intersectRectangle;
