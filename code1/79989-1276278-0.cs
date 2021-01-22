    class User 
    {
       public int userID {get; set;}
       private ISet subjects = new HashedSet();
       
       public ISet subjects {
          get { return subjects; }
          set { subjects = value; }
       }
    
       public void AddSubject(Subject subject)
       {
           subject.Users.Add(this);
           this.Subjects.Add(subject);
       }
    }
    
    class Subject
    {
       public int subjectID {get; set;}
       private ISet users = new HashedSet();
       
       public ISet users {
          get { return users; }
          set { users = value; }
       }
    
       public void AddUser(User user)
       {
           user.Subjects.Add(this);
           this.Users.Add(user);
       }
    }
