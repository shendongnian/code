        [LoggedUserFilter]
        public ActionResult LoadSomeEntity(int customerServiceID,int entityID)
        {
            UserRights userPermissionsView = Model.SecurityBO.GetUsersRightsOnEntity(SessionManager.LoggedUser.UserID, entityID);
 
            if(userPermissionsView.Write) 
                return View("EditEntity",Model.EntityBO.GetEntityByID(entityID));
            if(userPermissionsView.Read) 
                return View("ViewEntity",Model.EntityBO.GetEntityByID(entityID));
            return View("NotAuthorized");     
        }
