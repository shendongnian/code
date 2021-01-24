    switch (DocumentFileStatus)
    {
        case Enums.FileStatus.UnpublishedNotice:
        case Enums.FileStatus.UnpublishedOriginalNotice:
        case Enums.FileStatus.UnpublishedNewNoticeWithOpicData:
        case Enums.FileStatus.UnpublishedNewNotice:
            icon = IconType.UnpublishedNotice;
            break;
        case Enums.FileStatus.PublishedNotice:
        case Enums.FileStatus.PublishedOriginalNotice:
            icon = IconType.PublishedNotice;
            break;
    }
