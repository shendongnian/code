    public void StopAnimations()
    {
            foreach (GameObject CloneObject in GameObject.FindGameObjectsWithTag("*insert a custom tag like 'Clone'*"))
            {
                if (CloneObject.name == "*insert actual game object name here*")
                {
                    CloneObject.GetComponent<Animation>().Stop();              
                }
            }
    }
