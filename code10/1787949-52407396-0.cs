        Rect overlayRect = new Rect(0, 0, Screen.width, Screen.height);
                    GUI.BeginGroup(overlayRect);  // x,y,w,h
                    GUI.DrawTexture(overlayRect, btntexture);
        
                    Rect profileRect = new Rect((Screen.width) - (iconSize + (5 * DPinPixels)), 10, iconSize, iconSize);
                    GUI.DrawTexture(profileRect, profileViewTexture);
    
    
    if (GUI.Button(profileRect, "", new GUIStyle()))
                {
                    openProfileActivity();
                }
