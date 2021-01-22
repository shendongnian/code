    public bool SomeTest(int id1)
    {
       User user = userDao.GetById(id1);    
       if (user == null)
       {
          return false;
       }
       Blah blah = blahDao.GetById(user.BlahId);
       if (blah == null)
       {
           return false;
       }
        
       FooBar fb = fbDao.GetById(blah.FooBarId);
       if (fb == null)
       {
           return false;
       }
       return true;
    }
