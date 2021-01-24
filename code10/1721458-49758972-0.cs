    ...
            if (a.AppointmentId > 0)
            {
                //Update the event
                var getCeremonies = db.Appointments.Where(d => d.AppointmentId == a.AppointmentId).FirstOrDefault();
                if (v != null && getCeremonies != null)
                {
                    v.Appointments.Add(getVolunteer);
                    getCeremonies.Volunteers.Add(getVolunteer);
                }
            }
            db.SaveChanges();
