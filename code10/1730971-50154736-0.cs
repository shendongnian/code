    var property = _context.Property.Select(x => new 
       { Property = x,
         HMOUnits = x.HMOUnits,
         Notes = x.Notes,
         AttachmendId = new { Id = x.Attachments.Select(z=> z.AttachmentId) }
       })
       .SingleOrDefaultAsync(x =>
            x.Property.ID == key &&
           (RestrictUser(User) ? x.Property.Tenancies.Any(y => y.Assignments.Any(z => z.Tenant.UserID == Convert.ToInt32(User.Identity.Name))) : true) 
       );
