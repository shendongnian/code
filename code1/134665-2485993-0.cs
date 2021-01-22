    public void Update(int empid)
        {
            Employee person = this.dalService.GetByEntityId(empid);
            person.Name = "Process 1";
            // At this point , Update the Person table  manually using raw sql query
            // such as this 'Update Person Set Name = 'Process 2'where empid = @empid;
            
            // When the update is performed , it is expected to throw the exception , as the in memory data
            // is different from the one in database.
            if (username.equals("Bob"))
            {
                Thread.Sleep(50000);
                // If this is a website, have the above condition, so that it is simulated only for one user.
            }
            this.dalService.Update(person);
        }
     
