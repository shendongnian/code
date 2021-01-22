    class User 
    {
       public int userID {get; set;}
       public List<Subject> subjects {get; set;}
    
       public void AddSubject(Subject subject)
       {
           subject.Users.Add(this);
           this.Subjects.Add(subject);
       }
    }
    
    class Subject
    {
       public int subjectID {get; set;}
       public List<User> users {get; set;}
    
       public void AddUser(User user)
       {
           user.Subjects.Add(this);
           this.Users.Add(user);
       }
    }
