                switch (m.Msg)
                {
                    case WM_GESTURENOTIFY:
                        {
                        GESTURECONFIG gc = new GESTURECONFIG();
                        //Listen to required gestures here
                        //If 0, all gestures like pinching, panning, etc will be listened
                        //If GID_ZOOM, only pinching gesture will be listened
                        gc.dwID = IsPinchingPerformed ? 0 : GID_ZOOM;
                        gc.dwWant = GC_ALLGESTURES;
                        gc.dwBlock = 0;
    
                        bool result = SetGestureConfig(
                            handle,
                            0,
                            1,
                            ref gc,
                            _gestureConfigSize
                        );
    
                    }
                    break;
                    //... other codes if any
    }
