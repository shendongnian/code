    HERE I AM PASSING UserMasterDT  AS IN AND OUT 
        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, true)]
        public UserMasterDT UpdateUserWithTransaction(UserMasterDT tempuser)
        {
            int iRecUpdated = -1;
            Adapter.BeginTransaction();
            try
            {
                string sFlag = "UpdateUserRole";
                int iUserId = tempuser.UserId;
                int iRoleId = tempuser.RoleId;
                string sFirstname = tempuser.Firstname;
                string sLastname = tempuser.Lastname;
                int? iReturnData;
                //THIS OUT IS FROM MY SQL STORED PROCE NOT WITH OBJECTDATASOURCE OUT PARAMETER. IT HAS NOTHING TO DO WITH OBJECT DATA SOUCE.
                Adapter.UpdateUserRole(sFlag,iUserId,iRoleId,sFirstname,sLastname,out iReturnData);
                if (iReturnData == 1)
                {
                    iRecUpdated = 1;
                    this.Adapter.CommitTransaction();
                }
                else if (iReturnData == null)
                    iRecUpdated = -1;
                //What ever is return, set it back to UserMasterDT's iRecUpdated prop
                tempuser.iRecUpdated = iRecUpdated;
                return tempuser;
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    Adapter.RollbackTransaction();
                    //CustomEX objCUEx = new CustomEX(ex.Message, ex);
                    ex = null;
                    iRecUpdated = -1;    //-1 : Unexpected Error
                    //What ever is return, set it back to UserMasterDT's iRecUpdated prop
                    tempuser.iRecUpdated = iRecUpdated;
                    return tempuser;
                }
            }
            finally
            {
                tempuser.iRecUpdated = iRecUpdated;
            }
            //Return tempuser back
            return tempuser;
        }
