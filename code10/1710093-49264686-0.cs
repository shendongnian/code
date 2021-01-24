    var seg = context.TaskSegments
                            .Where(s => s.SegmentID == ID)
                            .Select(s => new
                            {
                                SegmentID = s.SegmentID,
                                TaskID = s.TaskID,
                                TaskType = s.Task.Type,
                                DisplayAs = s.Task.DisplayAs,
                                Value = s.Value,
                                CompletedOn = s.CompletedOn,
                                ModifiedBy = s.ModifiedBy,
                                ModifiedOn = s.ModifiedOn,
                                RequiresCompleteDate = s.Task.RequiresCompleteDate,
                                AllowAttachments = s.Task.AllowAttachments,
                                UseYesNoCompletion = s.Task.UseYesNoCompletion,
                                DisplayXWhenNotCompleted = s.Task.DisplayXWhenNotCompleted,
                                Responsible = s.Task.Responsible,
                                Secondary = s.Task.ResponsibleSecondary,
                                Confirmation = s.Task.Confirmation
                            })
                            .FirstOrDefault();
