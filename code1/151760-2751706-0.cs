    System.Threading.Thread thread = new System.Threading.Thread(
        new System.Threading.ThreadStart(
            delegate()
            {
                Console.Beep();
            }
        ));
    thread.Start();
