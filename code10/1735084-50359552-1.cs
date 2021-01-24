    // "GetInstance()" method is the same as "This" Keyword - long story
    public static void DisplayTask(Task task2Display)
        {
            dsplyrCntrls = new Task_DisplayrUsrCntrl(); // create new instance of user control
            // assign value to user control propeties
            dsplyrCntrls.TaskName = task2Display.taskName; 
            dsplyrCntrls.TaskDiscription = task2Display.dscription;
            dsplyrCntrls.Location = taskLocation;
            taskLocation.Offset(0, dsplyrCntrls.Size.Height + 10); // we do this so that the next task that is display is displayed ten "length" downward
                                                                   //   GetInstance().Controls.Add(groupBox); // draws the groupBox control onto the form
            GetInstance().Controls.Add(dsplyrCntrls); // adds user control to form so user can see
            int i = GetInstance().Controls.Count; // testing purpose - make sure control is added to form - which it is
            GetInstance().Show(); // shows the form
         
        }
