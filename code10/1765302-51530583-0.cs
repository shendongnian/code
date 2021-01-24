    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject[] foundObjects = FindObjectsOfType<GameObject>();
            Debug.Log("**** " + foundObjects + " : " + foundObjects.Length);
            var count = 0;
            if (foundObjects != null)
            {
                foreach (GameObject foundObject in foundObjects)
                {
                    count++;
                    if (foundObject.hideFlags == HideFlags.HideInHierarchy || foundObject.hideFlags == HideFlags.HideInInspector)
                    {
                        foundObject.hideFlags = HideFlags.None;
                        Debug.Log("**** foundObject: " + foundObject + " : foundObject Name: " + foundObject.name + " - Count: " + count);
                    }
                }
            }
        }
    }
	
	
