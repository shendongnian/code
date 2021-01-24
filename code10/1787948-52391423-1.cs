    void OnGUI()
    {
        if (showComponent)
        {
            // First only draw the GUI and set the bools
            bool isOverlayClicked;
            int onePartHeight = Screen.width / 10;
            GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));  // x,y,w,h
            GUI.backgroundColor = Color.clear;
            isOverlayClicked=  GUI.Button(new Rect(0, 0, Screen.width, (Screen.height / 2) + 100 + (onePartHeight * 2)), "");
            GUI.DrawTexture(new Rect(0, 0, Screen.width, (Screen.height / 2) + 100 + (onePartHeight * 2)), btntexture);
            thisMenu.blocksRaycasts = thisMenu.interactable = false;//disallows clicks
            thisMenu.alpha = 0;   //makes menu invisible
            GUILayout.EndArea();  
    
            bool isProfileButtonClicked;
            GUILayout.BeginArea(new Rect((Screen.width) - (iconSize + (25 * DPinPixels)), iconSize - (30 * DPinPixels), iconSize, iconSize));
            GUI.backgroundColor = Color.clear;
            isProfileButtonClicked = GUI.Button(new Rect(0, 0, iconSize, iconSize), "");
            GUI.DrawTexture(new Rect(0, 0, iconSize, iconSize), profileViewTexture);
            GUILayout.EndArea();
    
    
            // Than later only react to the bools
            if (isProfileButtonClicked)
            {
                Debug.Log("Profile icon clicked in unity");
                openProfileActivity();
                // Return so nothing else is executed
                return;
            }
    
            // This is only reached if the other button was not clicked
            if (isOverlayClicked)
            {
                Debug.Log("Overlay clicked in unity");
            }
        }
    }
