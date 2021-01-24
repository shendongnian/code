    Color oldColor = GUI.backgroundColor;
    GUI.backgroundColor = Color.red;
    // make copy of default button style 
    GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
 
    // change font size
    buttonStyle.fontSize = 18;
    bool searchButton = GUI.Button(new Rect(0, 55, 390, 30), "Search", buttonStyle);
    if (searchButton) {
        // ...
    }
