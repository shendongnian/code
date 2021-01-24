    _procedureService.Setup(x => x.GetUserVesselPermissions(It.IsAny<Guid>(), It.IsAny<DateTime>()))
    .Returns(new TestDbSqlQuery<UserVesselPermissionsResult>(new List<UserVesselPermissionsResult>
    {
        new UserVesselPermissionsResult
        {
            PermissionId = 1
        }
    }));
