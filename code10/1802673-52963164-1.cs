    void Update()
    {
        if (lastFrameList != null)
        {
            foreach (Custom c in currList)
            {
                if (!lastFrameList.Contains(c))
                {
                    //Do stuff for a newly added custom object
                    DoStuff()
                }
                if (c.Attributes_changed){
                    //Do stuff for changed attributes.
                    DoStuff()
                    c.Attributes_changed = false;
                }
            }
         }
         lastFrameList = currList.toList();
    }
