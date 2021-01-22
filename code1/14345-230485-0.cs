    List<string> responses = new List<string>();
    string response = "";
    
    while(!(response = Interaction.InputBox("Please enter your information",
                                            "Window Title",
                                            "Default Text",
                                            xPosition,
                                            yPosition)).equals(""))
    {
       responses.Add(response);
    }
    
    responses.ToArray();
