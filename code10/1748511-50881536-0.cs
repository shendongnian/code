    while (reader.Read())
                {
                    //create a new button object and use the prefab button to make sure spacing etc is correct
                    GameObject goButton = (GameObject)Instantiate(StudentNamePrefabButton);
                    //set the parent of the button
                    goButton.transform.SetParent(GridWithNameElements, false);
                    goButton.transform.localScale = new Vector3(1, 1, 1);
                    //set the text of the button. Array value is 0 as the student name is always at position 0 on each iteration
                    goButton.GetComponentsInChildren<Text>()[0].text = reader["fullName"].ToString() + " | " + reader["studentNumber"].ToString();
                    goButton.name = reader["studentID"].ToString();
    
                    Button tempButton = goButton.GetComponent<Button>();
                    int tempInt = i;
    
                    tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
    
                    i++;
    
                    Debug.Log(goButton.name);
                }
