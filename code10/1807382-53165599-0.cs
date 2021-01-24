    foreach (var screen in System.Windows.Forms.Screen.AllScreens)
        {
           Console.WriteLine("Device Name: " + screen.DeviceName);
          Console.WriteLine("Bounds: " + 
                screen.Bounds.ToString());
            Console.WriteLine("Type: " + 
                screen.GetType().ToString());
            Console.WriteLine("Working Area: " + 
                screen.WorkingArea.ToString());
            Console.WriteLine("Primary Screen: " + 
                screen.Primary.ToString());
        }
