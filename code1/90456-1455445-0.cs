    class tblAppointment
    {
        protected abstract void ProcessAppointment () ;
    }
    sealed class tblBirthAppointment
    {
        protected override void ProcessAppointment ()
        {
            // `this` is guaranteed to be tblBirthAppointment
            // do whatever you need
        }
    }
    ...
