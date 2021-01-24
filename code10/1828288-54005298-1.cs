    var members = _unitOfWork.SqlHelper.ReadRows("spGetMembersByUserCompanies", parameters, _memberProjection);
    readonly Func<SqlDataReader, MemberVm> _memberProjection = (r) => new MemberVm
        {
            InvitationId = r.Get<int?>("InvitationId"),
            UserName = r.Get<string>("UserName"),
            RoleName = r.Get<string>("RoleName"),
            InvitationStatus = (InvitationStatus)r.Get<int>("InvitationStatus"),
            LogoUrl = r.Get<string>("LogoUrl")
        };
