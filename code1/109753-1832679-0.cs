            IQueryable<Enquiry> visibleOnSite = EnquiryMethods.VisibleOnSite(db.Enquiries);
            var combinations = (from e in db.EnquiryAreas
                                from w in db.WorkTypes
                                where
                                w.HumanId != null &&
                                w.SeoPriority > 0 &&
                                e.HumanId != null &&
                                e.SeoPriority > 0 &&
                                visibleOnSite.Where(f => f.WhereId == e.Id && f.WhatId == w.Id).Any()
                                select
                                new
                                {
                                    EnquiryArea = e,
                                    WorkType = w
                                });
