        public static DataTable GetAllMembers(Guid workerID)
        {
            var AllEnrollees = from enrollment in context.tblCMOEnrollments
                                   where enrollment.CMOSocialWorkerID == workerID || enrollment.CMONurseID == workerID
                                   join supportWorker in context.tblSupportWorkers on enrollment.EconomicSupportWorkerID equals supportWorker.SupportWorkerID into workerGroup
                                   from worker in workerGroup.DefaultIfEmpty()
                                   let memberName = BLLConnect.MemberName(enrollment.ClientID)
                                   orderby enrollment.DisenrollmentDate ascending, memberName ascending
                                   select new
                                           {
                                               enrollment.ClientID,
                                               MemberName = memberName,
                                               NurseName = BLLAspnetdb.NurseName(enrollment.CMONurseID),
                                               SocialWorkerName =BLLAspnetdb.SocialWorkerName(enrollment.CMOSocialWorkerID),
                                               enrollment.DisenrollmentDate,
                                               enrollment.EnrollmentDate,
                                               ESFirstName = worker.FirstName,
                                               ESLastName = worker.LastName,
                                               ESPhone = worker.Phone
                                           };
            var dataTable = AllEnrollees.CopyLinqToDataTable();
            
            return dataTable;
        }
