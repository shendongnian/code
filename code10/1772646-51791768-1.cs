    public List<string> GetTeachersFromService()
    {
         // Call web service    
         if (webServiceResponse.teachers.count > 0)
              return webServiceResponse.teachers;
         else return null; 
    }
