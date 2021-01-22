            Screen[] screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length ; i++)
            {
                Debug.Print(screens[i].Bounds.ToString());
                Debug.Print(screens[i].DeviceName);
                Debug.Print(screens[i].WorkingArea.ToString());
            }
