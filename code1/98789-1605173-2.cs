    // User Management Orchestration Service
    interface IUserManagementService
    {
        User CreateUser();
    }
    
    // User Entity Service
    interface IUserService
    {
        User GetByKey(int key);
        User Insert(User user);
        User Update(User user);
        void Delete(User user);
    }
    
    // User Association Service
    interface IUserAssociationService
    {
        void AssociateWithLocation(User user, Location location);
        void AssociateWithAssignment(User user, Assignment assignment);
    }
    
    // Assignment Entity Service
    interface IAssignmentService
    {
        Assignment GetByKey(int key);
        // ... other CRUD operations ...
    }
    
    // Location Entity Service
    interface ILocationService
    {
        Location GetByKey(int key);
        // ... other CRUD operations ...
    }
