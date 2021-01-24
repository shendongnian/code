    Dictionary<Enums.FileStatus, IconType> dict = new Dictionary<Enums.FileStatus, IconType>()
    {
        { Enums.FileStatus.UnpublishedNotice , IconType.UnpublishedNotice },
        { Enums.FileStatus.UnpublishedOriginalNotice , IconType.UnpublishedNotice },
        { Enums.FileStatus.UnpublishedNewNoticeWithOpicData , IconType.UnpublishedNotice },
        { Enums.FileStatus.UnpublishedNewNotice, IconType.UnpublishedNotice },
        { Enums.FileStatus.PublishedNotice ,IconType.PublishedNotice },
        { Enums.FileStatus.PublishedOriginalNotice,IconType.PublishedNotice },
        { Enums.FileStatus.UnpublishedContractAward ,IconType.UnpublishedDocument },
        { Enums.FileStatus.UnpublishedFile ,IconType.UnpublishedDocument },
        { Enums.FileStatus.UnpublishedFileOtherReason, IconType.UnpublishedDocument },
        { Enums.FileStatus.PublishedAgreement ,IconType.PublishedDocument },
        { Enums.FileStatus.PublishedContractAward ,IconType.PublishedDocument },
        { Enums.FileStatus.PublishedCourtCase ,IconType.PublishedDocument },
        { Enums.FileStatus.PublishedFile ,IconType.PublishedDocument },
        { Enums.FileStatus.PublishedTender,IconType.PublishedDocument },
        { Enums.FileStatus.PublishedFileAfterTimeLimit,IconType.UnpublishedTenderingPeriod },
        { Enums.FileStatus.UnpublishedFileOtherReason, IconType.AlwaysUnpublished },
        { Enums.FileStatus.EmptyFile , IconType.BrokenDocument },
        { Enums.FileStatus.FileNotFound, IconType.BrokenDocument },
        { Enums.FileStatus.UnpublishedLink,IconType.UnpublishedLink },
        { Enums.FileStatus.PublishedLink,IconType.PublishedLink }
    };
    icon = dict[DocumentFileStatus];
