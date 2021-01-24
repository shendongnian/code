    switch ((sender as Button).Text)
    {
    
        case "1":
            serialMonitor.PrintLine("1");
            currentPressedCode = currentPressedCode + "1";
            break;
        case "2":
            serialMonitor.PrintLine("2");
            currentPressedCode = currentPressedCode + "2";
            break;
        case "3":
            serialMonitor.PrintLine("3");
            currentPressedCode = currentPressedCode + "3";
            break;
        default:
            break;
    }
    if (buttonsPressed == 3)
    {
        if (currentPressedCode == vaultCode)
        {
    
            //vault open
            serialMonitor.PrintLine("vault");
            pcbGreen.BackColor = Color.ForestGreen;
    
        }
        else
        {
            // wrong code
            serialMonitor.PrintLine("wrong");
            MessageBox.Show("Wrong password"); // wrong password messagebox
            pcbRed.BackColor = Color.DarkRed;
            
        }
        buttonsPressed = 0;
        currentPressedCode = "";
    }
