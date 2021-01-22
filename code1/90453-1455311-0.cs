    public tblSingleBirthAppointment GetBirthAppointment(int id)
    {
        var singleAppointment = GetAppointment(id);
    
        if (singleAppointment != null)
        {
            return (tblSingleBirthAppointment)singleAppointment;
        }
        return null;
    }
