    void MyReadString()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // Unity command to get the current scene info
        int buildIndex = currentScene.buildIndex; // Unity command to get the current scene number
        string path = null;
        // Create an empty string variable to hold the path information of text files
        switch (buildIndex)
        {
            case 0:
                path = "Assets/Scripts/some.txt"; //It says here that the variable path is assigned but never used!
                break;
            case 1:
                path = "Assets/Scripts/another.txt"; //Same here - assigned but never used. 
                break;
                // and many other cases - atleast 6 more
        }
        StreamReader reader = new StreamReader(path); // To read the text file                                               // And further string operations here - such as using a delimiter, finding the number of values in the text etc
    }
