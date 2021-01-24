     Messages = x.Messages?.Select(y => new MessageModel()
                {
                    Id = y.Id,
                    CreatorId = y.CreatorId,
                    Content = y.Content,
                    TimeSent = y.TimeSent,
                    GroupId = y.GroupId,
                    HasAttachment = y.HasAttachment,
                    AttachmentImage = y.AttachmentImage,
                    IsRead = y.IsRead
                }).ToList() ?? new List<MessageModel>(),
