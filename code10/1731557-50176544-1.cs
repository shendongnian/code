     bool firstTimeRun = true;
    
     void OnGUI()
     {    
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        addInteger = GUILayout.Toggle(addInteger, "Integers");
        howMuchIntegers = EditorGUILayout.IntField(howMuchIntegers);
    
        if(firstTimeRun)
        {
            intNames = new string[howMuchIntegers];
            if (addInteger)
            {
                if (howMuchIntegers != 0)
                {
                    GUILayout.BeginVertical("box");
                    for (int i = 0; i < howMuchIntegers; i++)
                    {
                        intNames[i] = i.ToString();
                        intNames[i] = EditorGUILayout.TextField(intNames[i]);
                    }
                    GUILayout.BeginVertical("box");
                }
            }
        
            firstTimeRun = false;
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        else
        {
            if (addInteger)
            {
                if (howMuchIntegers != 0)
                {
                    GUILayout.BeginVertical("box");
                    for (int i = 0; i < howMuchIntegers; i++)
                    {
                        intNames[i] = EditorGUILayout.TextField(intNames[i]);
                    }
                    GUILayout.BeginVertical("box");
                }
            }
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
     }
