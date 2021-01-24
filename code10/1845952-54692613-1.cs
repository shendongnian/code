    EditorGUILayout.BeginHorizontal();
    EditorGUILayout.PrefixLabel("position");
    EditorGUILayout.LabelField("X", GUILayout.Width(12));
    GUI.SetNextControlName("myX");
    var floatX = EditorGUILayout.FloatField(myTarget.posV3.x);
    EditorGUILayout.LabelField("Y", GUILayout.Width(12));
    GUI.SetNextControlName("myY");
    var floatY = EditorGUILayout.FloatField(myTarget.posV3.y);
    EditorGUILayout.LabelField("Z", GUILayout.Width(12));
    GUI.SetNextControlName("myZ");
    var floatZ = EditorGUILayout.FloatField(myTarget.posV3.z);
    EditorGUILayout.EndHorizontal();
    EditorGUILayout.HelpBox("Currently selected field is " + GUI.GetNameOfFocusedControl(), MessageType.None);
    EditorGUILayout.BeginHorizontal();
    var selectedField = GUI.GetNameOfFocusedControl();
    if (GUILayout.Button("-"))
    {
        switch (selectedField)
        {
            case "myX":
                floatX -= 0.01f;
                break;
            case "myY":
                floatY -= 0.01f;
                break;
            case "myZ":
                floatZ -= 0.01f;
                break;
        }
    }
    if (GUILayout.Button("+"))
    {
        switch (selectedField)
        {
            case "myX":
                floatX += 0.01f;
                break;
            case "myY":
                floatY += 0.01f;
                break;
            case "myZ":
                floatZ += 0.01f;
                break;
        }
    }
    EditorGUILayout.EndHorizontal();
    myTarget.posV3 = new Vector3(floatX, floatY, floatZ);
    
