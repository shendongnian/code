     public class CompanyFolderEntity : TableEntity
        {
            public CompanyFolderEntity(string companyId, string applicationId, string folderPath)
            {
                ApplicationId = applicationId;
                CompanyId = companyId;
                FolderPath = folderPath;
            }
    
            public CompanyFolderEntity()
            {
    
            }    
            
            public string FolderPath { get; set; }
    
            public string ApplicationId { get; set; }    
            
            public string CompanyId { get; set; }
        }
    }
