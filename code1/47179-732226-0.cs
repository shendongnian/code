            private bool ignoreNext = false;
            void HookManager_MouseMoveExt(object sender, MouseEventExtArgs e)
            {
                // Should we block all mouse interactions?
                if (Block) {
                    e.Handled = true;
                    return;
                }
    
                // Return if we should ignore the nex, because we made a big jump
                if (ignoreNext) {
                    ignoreNext = false;
                    return;
                }
    
                if (hasControl) 
                {
                    // Lock the mouse to 100,100 : 200,200 and flip back to 150,150 if out of bounds
                    if (e.X < 100 || e.X > 200 || e.Y < 100 || e.Y > 200) // Box leaved
                    {
                        // If we leave the box, we set the position to the center 
                        // and set the event to handled otherwise the mouse is free
                        MouseSimulator.Position = new System.Drawing.Point(150, 150);
                        e.Handled = true;
                        ignoreNext = true;
                    }
    
                    // We moved fine, send the delta to the server
                    // The MouseSimulator.Position change will not be visible yet.
                    server.MouseMove(e.DeltaX, e.DeltaY, true);
    
                }
    
                Logger.Log(String.Format("Pos: {0} {1} Delta: {2} {3}", e.X, e.Y, e.DeltaX, e.DeltaY), LogLevel.Info);
            }
