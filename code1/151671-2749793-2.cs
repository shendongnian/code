    void Init(ApplicationEntity ae)
    {
        EventResult result = EventResult.Success;
        AuditedInstances loadedInstances = new AuditedInstances();
        try
        {
    
            XmlDocument doc = RetrieveHeaderXml(studyLoaderArgs);
            StudyXml studyXml = new StudyXml();
            studyXml.SetMemento(doc);
    
            _instances = GetInstances(studyXml).GetEnumerator();
    
            loadedInstances.AddInstance(studyXml.PatientId, studyXml.PatientsName, studyXml.StudyInstanceUid);
    
            return studyXml.NumberOfStudyRelatedInstances;
    
        } 
        finally 
        {
            AuditHelper.LogOpenStudies(new string[] { ae.AETitle }, loadedInstances, EventSource.CurrentUser, result);
        }
    
    }
