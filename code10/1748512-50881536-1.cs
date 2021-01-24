    //This method is called when the student attempts to search for their own name when taking the individual quiz
    public void SearchExistingStudentName()
    {
        //Get the name entered from the text field
        string student_name = searchExistingStudentNameInput.text;
        //Create a list to store all the user names
        List<string> filteredNamesList = new List<string>();
        //Add another list to store the user unique ids
        List<string> filteredNameIDList = new List<string>();
        //Clear both lists before using them
        filteredNamesList.Clear();
        filteredNameIDList.Clear();
        //sets an id to the onclick listener of newly created buttons
        int x = 0;
        //if a new button object exists and the name was entered and then removed, clear it from the list and remove the created button
        if (student_name == "")
        {
            //Clear the filtered filteredNamesList List
            filteredNamesList.Clear();
            filteredNameIDList.Clear();
            x = 0;
            //Destroy the create filter buttons if the user clears the text area
            GameObject[] objects = GameObject.FindGameObjectsWithTag("filterButton");
            //loop through the buttons that share the tag "filterButton"
            for (int count = 0; count < objects.Length; count++)
            {
                Destroy(objects[count]);
                Debug.Log("Number of objects to be deleted " + objects.Length);
            }
            //Loop through and show all children 
            foreach (Transform child in GridWithNameElements)
            {
                child.gameObject.SetActive(true);
            }
            GridWithNameElements.gameObject.SetActive(true);
            GridWithNameElements2.gameObject.SetActive(false);
        }
        else if (student_name != "")
        {
            //loop through the list of buttons in the main/unfiltered list with student filteredNamesList
            for (int i = 0; i < GridWithNameElements.childCount; i++)
            {
                //Check if the user has typed their name with capitals or lowercase etc, and check the inputted value against filteredNamesList already in the list
                //If true, proceed 
                //Get the name value that contains entered character
                if (GridWithNameElements
                   .GetComponentsInChildren<Text>()[i].text.Contains(student_name) || GridWithNameElements
                   .GetComponentsInChildren<Text>()[i].text.ToLower().Contains(student_name) || GridWithNameElements
                   .GetComponentsInChildren<Text>()[i].text.ToUpper().Contains(student_name))
                {
                    //Do not allow duplicates to the list
                    if (filteredNamesList.Distinct().Count() == filteredNamesList.Count())
                    {
                        //If the name entered contains letters found in the parent GridWithNameElements, then add them to the list array and their name value (unique id)
                        filteredNamesList.Add(GridWithNameElements.GetComponentsInChildren<Text>()[i].text.Replace(@"[", string.Empty).Replace(@"]", string.Empty));
                        filteredNameIDList.Add(GridWithNameElements.GetChild(i).name); //this is the unique id of the student
                    }
                    //end of if statement   
                }
                //end of main loop
            }
            //hide original list
            GridWithNameElements.gameObject.SetActive(false);
            //show filtered list
            GridWithNameElements2.gameObject.SetActive(true);
            //Destroy the created filter buttons if the user presses another button, as previously 
            //added filteredNamesList might need to be ruled out. 
            GameObject[] objects = GameObject.FindGameObjectsWithTag("filterButton");
            //loop through the buttons that share the tag "filterButton"
            for (int count = 0; count < objects.Length; count++)
            {
                Destroy(objects[count]);
                Debug.Log("Number of objects to be deleted " + objects.Length);
            }
            int filteredNameIDCount = 0;
            foreach (string nameInList in filteredNamesList)
            {
                
                //Then create a button that represents a name added to the filteredNamesList List
                newButton = Instantiate(StudentNamePrefabButton);
                //set the parent of the button
                newButton.transform.SetParent(GridWithNameElements2, false);
                newButton.transform.localScale = new Vector3(1, 1, 1);
                //set the text of the button. Array value is 0 as the student name is always at position 0 on each iteration
                newButton.GetComponentsInChildren<Text>()[0].text = nameInList.ToString();
                newButton.name = filteredNameIDList[filteredNameIDCount].ToString().Trim();
                newButton.tag = "filterButton";
                Debug.Log("Filtered Name " + nameInList.ToString() + " Their ID " + filteredNameIDList[filteredNameIDCount].ToString().Trim());
                filteredNameIDCount++;
            }
            //end of loop
            //Then add a click listener to the button
            Button tempButton = newButton.GetComponent<Button>();
            int tempInt = x;
            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
            x++;
            // Debug.Log("Student Unique ID " + newButton.name);
        }
    }
